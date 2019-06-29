using Microsoft.EntityFrameworkCore;
using MuseeMe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseeMe.Server.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Audio> Audios { get; set; }
    }
}
