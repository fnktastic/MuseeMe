using System;
using System.Collections.Generic;
using System.Text;

namespace MuseeMe.Data
{
    public class AudioFile
    {
        public Guid AudioId { get; set; }

        public Byte[] FileData { get; set; }
    }
}
