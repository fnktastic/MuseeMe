using System;
using System.Collections.Generic;
using System.Text;

namespace MuseeMe.Model
{
    public class AudioFile
    {
        public Guid AudioId { get; set; }

        public Byte[] FileData { get; set; }
    }
}
