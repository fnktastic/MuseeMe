using Microsoft.EntityFrameworkCore;
using MuseeMe.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuseeMe.DataAccess
{
    public class Context : DbContext
    {
        private readonly string _databasePath;

        public DbSet<Audio> Audios { get; set; }

        public Context(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
