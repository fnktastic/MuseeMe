using MuseeMe.Data;
using MuseeMe.Server.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseeMe.Server.Repository
{
    public interface IAudioRepository : IGenericService<Audio>
    {
        Task AddFileAsync(Byte[] fileBytes);
        Task<Byte[]> GetFileAsync(Guid id);
    }

    public class AudioRepository : IAudioRepository
    {
        private readonly Context _context;

        public AudioRepository(Context context)
        {
            _context = context;
        }

        public Task AddFileAsync(byte[] fileBytes)
        {
            throw new NotImplementedException();
        }

        public Task<Byte[]> GetFileAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddItemAsync(Audio item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Audio item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Audio> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Audio>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
