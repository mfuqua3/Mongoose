using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mongoose.Core.Entities;
using Mongoose.Core.Repository;
using Mongoose.Models;

namespace Mongoose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public EpisodesController(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }
        [HttpGet("{seasonId}")]
        public async Task<IActionResult> GetEpisodesBySeason(int seasonId)
        {
            var episodes = await _episodeRepository.GetAllEpisodesBySeason(seasonId);
            var models = _mapper.Map<List<Episode>, List<EpisodeViewModel>>(episodes);
            return new JsonResult(models);
        }
        [HttpGet]
        public async Task<IActionResult> GetEpisodesBySeries([FromQuery] int seriesId)
        {
            var episodes = await _episodeRepository.GetAllEpisodesBySeries(seriesId);
            var models = _mapper.Map<List<Episode>, List<EpisodeViewModel>>(episodes);
            return new JsonResult(models);
        }
        [HttpPost]
        public async Task<IActionResult> PostEpisode([FromBody] EpisodeViewModel episode)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (episode.SeasonId == default)
                return BadRequest("A season ID must be provided");
            var entity = _mapper.Map<EpisodeViewModel, Episode>(episode);
            await _episodeRepository.PostEpisode(entity);
            await _episodeRepository.SaveChanges();
            _mapper.Map(entity, episode);
            return Created("", episode);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEpisode([FromBody] EpisodeViewModel episode)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (episode.Id == default)
                return BadRequest("An episode ID must be provided.");
            var entity = await _episodeRepository.GetEpisode(episode.Id);
            if (entity == null)
                return BadRequest("No episode could be found to update.");
            _mapper.Map(episode, entity);
            await _episodeRepository.SaveChanges();
            return new JsonResult(episode);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            var deleted =await _episodeRepository.DeleteEpisode(id);
            if (!deleted)
                return BadRequest("No episode could be found to delete");
            await _episodeRepository.SaveChanges();
            return NoContent();
        }
    }
}
