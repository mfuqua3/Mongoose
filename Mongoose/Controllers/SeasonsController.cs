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
    public class SeasonsController : ControllerBase
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;

        public SeasonsController(ISeasonRepository seasonRepository, IMapper mapper)
        {
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }
        [HttpGet("{seriesId}")]
        public async Task<IActionResult> GetSeasons(int seriesId)
        {
            var seasons = await _seasonRepository.GetAllSeasonsBySeries(seriesId);
            var models = _mapper.Map<List<Season>, List<SeasonViewModel>>(seasons);
            return new JsonResult(models);
        }
        [HttpPost]
        public async Task<IActionResult> PostSeason([FromBody] SeasonViewModel season)
        {
            if (season.SeriesId == default)
                return BadRequest("A valid series ID must be provided");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = _mapper.Map<SeasonViewModel, Season>(season);
            await _seasonRepository.PostSeason(entity);
            await _seasonRepository.SaveChanges();
            _mapper.Map(entity, season);
            return Created("", season);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeason([FromBody] SeasonViewModel season)
        {
            if (season.Id == default)
                return BadRequest("A valid season ID must be provided");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            season.Episodes = null;
            var entity = await _seasonRepository.GetSeason(season.Id);
            if (entity == null)
                return BadRequest("No season could be found to update.");
            _mapper.Map(season, entity);
            await _seasonRepository.SaveChanges();
            return new JsonResult(season);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            var deleted = await _seasonRepository.DeleteSeason(id);
            if (!deleted)
                return BadRequest("No season could be found to delete.");
            await _seasonRepository.SaveChanges();
            return NoContent();
        }
    }
}
