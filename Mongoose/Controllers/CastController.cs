using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoogleCast;
using GoogleCast.Channels;
using GoogleCast.Models.Media;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mongoose.Core.Repository;
using Mongoose.Models;

namespace Mongoose.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CastController> _logger;
        private readonly IEpisodeRepository _episodeRepository;

        public CastController(IMapper mapper, ILogger<CastController> logger, IEpisodeRepository episodeRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _episodeRepository = episodeRepository;
        }
        [HttpGet("devices")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await GetReceivers();
            var deviceModels = _mapper.Map<List<IReceiver>, List<CastReceiverViewModel>>(devices.ToList());
            return new JsonResult(deviceModels);
        }
        [HttpGet("connect/{id}")]
        public async Task<IActionResult> Connect(string id, [FromQuery] int episodeId)
        {
            var episode = await _episodeRepository.GetEpisode(episodeId);
            var videoInfo = episode?.VideoInfo;
            if (videoInfo == null)
            {
                return BadRequest("The requested video could not be found");
            }
            var devices = await GetReceivers();
            var target = devices.FirstOrDefault(rcvr => rcvr.Id == id);
            if (target == null)
            {
                return BadRequest("That device is not available to cast.");
            }
            var sender = new Sender();
            await sender.ConnectAsync(target);
            var mediaChannel = sender.GetChannel<IMediaChannel>();
            await sender.LaunchAsync(mediaChannel);
            var mediaStatus = await mediaChannel.LoadAsync(
                new MediaInformation()
                {
                    ContentId = $"http://192.168.0.119:5000/{videoInfo.FilePath}",
                    ContentType = "video/mp4",
                });
            return Ok(mediaStatus);
        }

        private async Task<IEnumerable<IReceiver>> GetReceivers()
        {

            var deviceLocator = new DeviceLocator();
            return await deviceLocator.FindReceiversAsync();
        }
    }
}