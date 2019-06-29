using System;
using System.IO;
using Xamarin.Forms;
using MuseeMe.DataAccess;
using MuseeMe.Droid;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace MuseeMe.Droid
{
    public class AndroidDbPath : IDatabasePath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}