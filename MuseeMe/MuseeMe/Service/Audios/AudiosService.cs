using MuseeMe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseeMe.Service.Audios
{
    public interface IAudiosService : IGenericService<Audio>
    {

    }

    public class AudiosService : IAudiosService
    {
        private readonly List<Audio> _audios;

        public AudiosService()
        {
            _audios = new List<Audio>();

            var mockAudios = new List<Audio>
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
                    Name = "New World",
                    Year = 2015
                },
            };

            _audios.AddRange(mockAudios);
        }

        public async Task<bool> AddItemAsync(Audio item)
        {
            _audios.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Audio item)
        {
            var oldItem = _audios.Where(arg => arg.Id == item.Id).FirstOrDefault();

            _audios.Remove(oldItem);

            _audios.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = _audios.Where(arg => arg.Id == id).FirstOrDefault();

            _audios.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Audio> GetItemAsync(Guid id)
        {
            return await Task.FromResult(_audios.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Audio>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_audios);
        }
    }
}
