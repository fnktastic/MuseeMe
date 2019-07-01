using MuseeMe.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static TagLib.File;

namespace MuseeMe.Utility
{
    public static class AudioTagHelper
    {
        public static Audio Read(string path, byte[] fileData)
        {
            var fileAbstraction = new AudioFileAbstraction(path, fileData);

            var tags = Create(fileAbstraction);

            return new Audio()
            {
                Album = tags.Tag.Album,
                Artist = tags.Tag.JoinedPerformers,
                CreatedAt = DateTime.UtcNow,
                Duration = TimeSpan.FromSeconds(tags.Length),
                FileName = path,
                Genre = tags.Tag.FirstGenre,
                ModifiedAt = DateTime.UtcNow,
                Name = tags.Tag.Title,
                Year = int.Parse(tags.Tag.Year.ToString())
            };
        }
    }

    public class AudioFileAbstraction : IFileAbstraction
    {
        private readonly string _fileName;

        private readonly Byte[] _fileData;

        private Stream _stream;

        public AudioFileAbstraction(String fileName, Byte[] fileData)
        {
            _fileName = fileName;
            _fileData = fileData;
            _stream = new MemoryStream();
        }

        public string Name
        {
            get
            {
                return _fileName;
            }
        }

        public Stream ReadStream
        {
            get
            {
                _stream.Write(_fileData, 0, _fileData.Length);
                return _stream;
            }
        }

        public Stream WriteStream
        {
            get
            {
                _stream.Write(_fileData, 0, _fileData.Length);
                return _stream;
            }
        }

        public void CloseStream(Stream stream)
        {
            _stream.Dispose();
        }
    }
}
