using Flurl;
using Flurl.Http;
using MuseeMe.Data;
using MuseeMe.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
        private readonly string _basePath;

        public FilesService()
        { 
            _basePath = App.ServerBaseUrl;
        }

        public async Task<bool> AddItemAsync(AudioFile item)
        {
            var response = await _basePath.AppendPathSegments("api", "audios", "AddFileAsync").PostJsonAsync(item);

            return response.IsSuccessStatusCode;
        }

        public async Task<AudioFile> GetItemAsync(Guid id)
        {
            var audioFile = await _basePath.AppendPathSegments("api", "audios", "GetFileAsync", id).GetJsonAsync<AudioFile>();

            if (audioFile != null)
                return audioFile;

            return null;
        }
    }
}
