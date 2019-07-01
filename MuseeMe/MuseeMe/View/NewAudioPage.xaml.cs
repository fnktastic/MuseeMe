using MuseeMe.Utility;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuseeMe.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAudioPage : ContentPage
    {
        private string fileName;

        public FileData PickedFile { get; private set; }

        public NewAudioPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void BrowseAudio_Click(object sender, EventArgs args)
        {
            try
            {
                PickedFile = await CrossFilePicker.Current.PickFile(null);

                if (PickedFile != null)
                {
                    fileName = PickedFile.FilePath;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void AddAudio_Click(object sender, EventArgs args)
        {
            try
            {
                MessagingCenter.Send(this, "AddAudio");

                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}