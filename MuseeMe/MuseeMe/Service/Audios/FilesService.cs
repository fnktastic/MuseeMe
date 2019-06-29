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
        Task<Uri> AddItemAsync(AudioFile item);

        Task<AudioFile> GetItemAsync(Guid id);
    }

    public class FilesService : IFilesService
    {
        private readonly HttpClient _client;

        private readonly string basePath;

        public FilesService()
        {
            _client = new HttpClient();

            basePath = Path.Combine(App.ServerBaseUrl, "api", "audios");
        }

        public async Task<Uri> AddItemAsync(AudioFile item)
        {
            string currentPath = Path.Combine(basePath, "AddFileAsync");

            string json = JsonConvert.SerializeObject(item);

            HttpContent content = new StringContent(json);

            HttpResponseMessage response = await _client.PostAsync(currentPath, content);

            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public async Task<AudioFile> GetItemAsync(Guid id)
        {
            string currentPath = Path.Combine(basePath, "GetFileAsync", id.ToString());

            string response = await _client.GetStringAsync(currentPath);

            return JsonConvert.DeserializeObject<AudioFile>(response);
        }
    }
}
