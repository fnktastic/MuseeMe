using System;
using System.Collections.Generic;
using System.Text;

namespace MuseeMe.DataAccess
{
    public interface IDatabasePath
    {
        string GetDatabasePath(string filename);
    }
}
