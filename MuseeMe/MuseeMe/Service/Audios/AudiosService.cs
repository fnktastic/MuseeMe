using MuseeMe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MuseeMe.Service.Audios
{
    public interface IAudiosService : IGenericService<Audio>
    {

    }

    public class AudiosService : IAudiosService
    {
        private readonly HttpClient _client;

        private readonly List<Audio> _audios;

        public AudiosService()
        {
            _audios = new List<Audio>();
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
