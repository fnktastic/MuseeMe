using Microsoft.EntityFrameworkCore;
using MuseeMe.Data;
using MuseeMe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MuseeMe.Repository.Audios
{
    public interface IAudiosRepository : IGenericRepository<Audio>
    {

    }

    public class AudiosRepository : IAudiosRepository
    {
        private readonly string dbPath;

        public AudiosRepository()
        {
            dbPath = DependencyService.Get<IDatabasePath>().GetDatabasePath(App.DbFilename);
        }

        public async Task<bool> AddItemAsync(Audio item)
        {
            using (var _context = new Context(dbPath))
            {
                await _context.Audios.AddAsync(item);

                await _context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> UpdateItemAsync(Audio item)
        {
            using (var _context = new Context(dbPath))
            {
                var dbEntry = _context.Audios.FirstOrDefault(x => x.Id == item.Id);

                if (dbEntry != null)
                {
                    dbEntry.Album = item.Album;
                    dbEntry.Artist = item.Artist;
                    dbEntry.CreatedAt = item.CreatedAt;
                    dbEntry.Duration = item.Duration;
                    dbEntry.FileName = item.FileName;
                    dbEntry.Genre = item.Genre;
                    dbEntry.ModifiedAt = DateTime.UtcNow;
                    dbEntry.Name = item.Name;
                    dbEntry.Year = item.Year;

                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            using (var _context = new Context(dbPath))
            {
                var dbEntry = _context.Audios.FirstOrDefault(x => x.Id == id);

                if (dbEntry != null)
                {
                    _context.Entry(dbEntry).State = EntityState.Deleted;

                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<Audio> GetItemAsync(Guid id)
        {
            using (var _context = new Context(dbPath))
            {
                return await _context.Audios.FindAsync(id);
            }
        }

        public async Task<IEnumerable<Audio>> GetItemsAsync(bool forceRefresh = false)
        {
            using (var _context = new Context(dbPath))
            {
                return await _context.Audios.ToListAsync();
            }
        }
    }
}
