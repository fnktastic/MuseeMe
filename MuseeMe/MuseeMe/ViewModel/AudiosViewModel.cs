using MuseeMe.Data;
using MuseeMe.Extension;
using MuseeMe.Utility;
using MuseeMe.View;
using PCLStorage;
using Plugin.MediaManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FileAccess = PCLStorage.FileAccess;

namespace MuseeMe.ViewModel
{
    public class AudiosViewModel : BaseViewModel
    {
        public ObservableCollection<Audio> Audios { get; set; }
        public Command LoadAudiosCommand { get; set; }

        public AudiosViewModel()
        {
            Title = "Audios";
            Audios = new ObservableCollection<Audio>();
            LoadAudiosCommand = new Command(async () => await ExecuteLoadAudiosCommand());

            MessagingCenter.Subscribe<NewAudioPage>(this, "AddAudio", async (obj) =>
            {
                try
                {
                    IsBusy = true;
                    var audio = AudioTagHelper.Read(obj.PickedFile.FilePath, obj.PickedFile.DataArray);

                    var isAudioAdded = await AudiosRepository.AddItemAsync(audio);

                    if (isAudioAdded)
                    {
                        Audios.Add(audio);

                        var audioFile = new AudioFile(audio.Id, obj.PickedFile.DataArray);

                        var isFileAdded = await FilesService.AddItemAsync(audioFile);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    IsBusy = false;
                }
            });
        }

        async Task ExecuteLoadAudiosCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Audios.Clear();

                var audios = await AudiosRepository.GetItemsAsync();

                foreach (var audio in audios)
                {
                    Audios.Add(audio);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #region public methods
        public async Task SelectAudio(Audio audio)
        {

            string fileName = Path.GetFileName(audio.FileName);

            string folderName = Path.GetDirectoryName(audio.FileName);

            IFolder folder = await FileSystem.Current.GetFolderFromPathAsync(folderName);

            bool exist = await fileName.IsFileExistAsync(folder);

            if (exist == true)
            {
                IFile file = await folder.GetFileAsync(fileName);

                await CrossMediaManager.Current.Play(audio.FileName);
            }

            if (exist == false)
            {
                var audioFile = await FilesService.GetItemAsync(audio.Id);
                folder = FileSystem.Current.LocalStorage;
                IFile file = await folder.CreateFileAsync(audio.Id.ToString(), CreationCollisionOption.ReplaceExisting);
                var stream = await file.OpenAsync(FileAccess.ReadAndWrite);
                await stream.WriteAsync(audioFile.FileData, 0, audioFile.FileData.Length);
                stream.Dispose();
            }

            await AudiosRepository.UpdateItemAsync(audio);
        }
        #endregion
    }
}
