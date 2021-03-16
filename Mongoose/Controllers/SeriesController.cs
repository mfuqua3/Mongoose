using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mongoose.Core.Entities;
using Mongoose.Core.Repository;
using Mongoose.Models;

namespace Mongoose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public SeriesController(ISeriesRepository seriesRepository, IMapper mapper)
        {
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSeries()
        {
            var series = await _seriesRepository.GetAllSeries();
            var seriesModels = _mapper.Map<List<Series>, List<SeriesViewModel>>(series);
            return new JsonResult(seriesModels);
        }
        [HttpPost]
        public async Task<IActionResult> PostSeries([FromBody] SeriesViewModel series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nameExists = (await _seriesRepository.GetSeriesByName(series.Name)) != null;
            if (nameExists)
            {
                return BadRequest("A series by that name already exists.");
            }

            var entity = _mapper.Map<SeriesViewModel, Series>(series);
            await _seriesRepository.PostSeries(entity);
            await _seriesRepository.SaveChanges();
            _mapper.Map(entity, series);
            return Created("", series);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeries([FromBody] SeriesViewModel series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (series.Id == 0)
                return BadRequest("A series ID must be specified.");
            series.Seasons = null;
            var entity = await _seriesRepository.GetSeriesById(series.Id);
            if (entity == null)
                return BadRequest("No series could be found with the specified ID");
            _mapper.Map(series, entity);
            await _seriesRepository.SaveChanges();
            return Ok(series);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var deleted = await _seriesRepository.DeleteSeries(id);
            if (!deleted)
                return BadRequest("No series with that ID could be deleted");
            await _seriesRepository.SaveChanges();
            return NoContent();
        }
    }
}
