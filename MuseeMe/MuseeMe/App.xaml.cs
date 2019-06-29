using MuseeMe.Data;
using MuseeMe.DataAccess;
using MuseeMe.Repository.Audios;
using MuseeMe.Service.Audios;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MuseeMe
{
    public partial class App : Application
    {
        public static string ServerBaseUrl = "http://localhost:50677/";
        public static string DbFilename = "museeme.db";

        public App()
        {
            InitializeComponent();

            string dbPath = DependencyService.Get<IDatabasePath>().GetDatabasePath(DbFilename);

            DependencyService.Register<IAudiosService, AudiosService>();
            DependencyService.Register<IAudiosRepository, AudiosRepository>();
            DependencyService.Register<IFilesService, FilesService>();

            using (var db = new Context(dbPath))
            {
                db.Database.EnsureCreated();
                if (db.Audios.Count() == 0)
                {
                    db.Audios.AddRange(new List<Audio>
                    {
                        new Audio
                        {
                            Album = "Simin",
                            Artist = "Static Movement",
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.UtcNow,
                            Duration = TimeSpan.FromMinutes(5),
                            FileName = "static_movement_-_rage.mp3",
                            Genre = "Goa",
                            Name = "Rage",
                            Year = 2015
                        },
                        new Audio
                        {
                            Album = "Simin",
                            Artist = "Static Movement",
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.UtcNow,
                            Duration = TimeSpan.FromMinutes(5),
                            FileName = "static_movement_-_simin.mp3",
                            Genre = "Goa",
                            Name = "Simin",
                            Year = 2019
                        },
                        new Audio
                        {
                            Album = "Simin",
                            Artist = "Static Movement",
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.UtcNow,
                            Duration = TimeSpan.FromMinutes(5),
                            FileName = "static_movement_-_simin.mp3",
                            Genre = "Goa",
                            Name = "New World",
                            Year = 2012
                        },
                        new Audio
                        {
                            Album = "Deluxe",
                            Artist = "Dua Lipa",
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.UtcNow,
                            Duration = TimeSpan.FromMinutes(8),
                            FileName = "dua_lipa_-_last_dance.mp3",
                            Genre = "Pop",
                            Name = "Last Dance",
                            Year = 2017
                        },
                    });
                }

                db.SaveChanges();
            }

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
