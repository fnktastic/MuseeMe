using MuseeMe.Service.Audios;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MuseeMe
{
    public partial class App : Application
    {
        public static string ServerBaseUrl = "";
        public static bool UseMockData = true;

        public App()
        {
            InitializeComponent();
            if (UseMockData)
                DependencyService.Register<IAudiosService, AudiosService>();
            else
                DependencyService.Register<IAudiosService, AudiosService>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
