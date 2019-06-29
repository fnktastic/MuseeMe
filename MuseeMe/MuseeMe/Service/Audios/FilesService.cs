using MuseeMe.Data;
using MuseeMe.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuseeMe.Service.Audios
{
    public interface IFilesService
    {
        Task<bool> AddItemAsync(AudioFile item);

        Task<AudioFile> GetItemAsync(Guid id);
    }

    public class FilesService : IFilesService
    {
        public Task<bool> AddItemAsync(AudioFile item)
        {
            throw new NotImplementedException();
        }

        public Task<AudioFile> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
