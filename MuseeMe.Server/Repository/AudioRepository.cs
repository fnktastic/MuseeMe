using Microsoft.AspNetCore.Hosting;
using MuseeMe.Data;
using MuseeMe.Server.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MuseeMe.Server.Repository
{
    public interface IAudioRepository : IGenericService<Audio>
    {
        Task AddFileAsync(AudioFile audioFile);
        Task<AudioFile> GetFileAsync(Guid id);
    }

    public class AudioRepository : IAudioRepository
    {
        private readonly Context _context;

        private readonly IHostingEnvironment _hostingEnvironment;

        public AudioRepository(Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task AddFileAsync(AudioFile audioFile)
        {
            await Task.Run(() =>
            {
                string path = Path.Combine(_hostingEnvironment.WebRootPath, $"{audioFile.AudioId}");

                File.WriteAllBytes(path, audioFile.FileData);
            });
        }

        public async Task<AudioFile> GetFileAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                string path = Path.Combine(_hostingEnvironment.WebRootPath, $"{id}");

                var filedata = File.ReadAllBytes(path);

                return new AudioFile()
                {
                    FileData = filedata,
                    AudioId = id
                };
            });
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
