using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


    }
}