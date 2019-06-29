using MuseeMe.Data;
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
    }
}
