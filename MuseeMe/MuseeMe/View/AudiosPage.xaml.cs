using MuseeMe.Data;
using MuseeMe.ViewModel;
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
	public partial class AudiosPage : ContentPage
	{
        AudiosViewModel viewModel;

		public AudiosPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new AudiosViewModel();
		}

        private async void AudiosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var audio = e.SelectedItem as Audio;
            if (audio == null)
                return;

            AudiosListView.SelectedItem = null;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Audios.Count == 0)
                viewModel.LoadAudiosCommand.Execute(null);
        }
    }
}