using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuseeMe.Data;
using MuseeMe.Server.Repository;

namespace MuseeMe.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudiosController : ControllerBase
    {
        private readonly IAudioRepository _audioRepository;

        public AudiosController(IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
        }

        [HttpGet("GetFileAsync/{id}")]
        public async Task<ActionResult<AudioFile>> GetFileAsync(Guid id)
        {
            return await _audioRepository.GetFileAsync(id);
        }

        [HttpPost("AddFileAsync")]
        public async Task AddFileAsync([FromBody] AudioFile audioFile)
        {
            await _audioRepository.AddFileAsync(audioFile);
        }
    }
}