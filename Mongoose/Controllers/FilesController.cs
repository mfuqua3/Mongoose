using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Mongoose.Models;
using Mongoose.Service;

namespace Mongoose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IVideoFileService _videoFileService;

        public FilesController(IVideoFileService videoFileService)
        {
            _videoFileService = videoFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var files = await _videoFileService.GetAllVideoFiles();
            return new JsonResult(files);
        }
        [HttpGet("unmapped")]
        public async Task<IActionResult> GetAllUnmappedFiles()
        {
            var files = await _videoFileService.GetUnmappedVideoFiles();
            return new JsonResult(files);
        }
    }
}
