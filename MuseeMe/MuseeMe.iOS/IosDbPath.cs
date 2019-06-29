using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using MuseeMe.DataAccess;
using MuseeMe.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosDbPath))]
namespace MuseeMe.iOS
{
    public class IosDbPath : IDatabasePath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", sqliteFilename);
        }
    }
}