using MuseeMe.Data;
using MuseeMe.Utility;
using MuseeMe.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
                var audio = AudioTagHelper.Read(obj.PickedFile.FileName, obj.PickedFile.DataArray);

                var isAudioAdded = await AudiosRepository.AddItemAsync(audio);

                if(isAudioAdded)
                {
                    Audios.Add(audio);

                    var audioFile = new AudioFile(audio.Id, obj.PickedFile.DataArray);

                    var isFileAdded = await FilesService.AddItemAsync(audioFile);
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

                foreach(var audio in audios)
                {
                    Audios.Add(audio);
                }
            }
            catch(Exception ex)
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
            var audioFile = await FilesService.GetItemAsync(audio.Id);
        }
        #endregion
    }
}
