using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Mongoose.Core.Repository;
using Mongoose.Models;

namespace Mongoose.Service
{
    public class VideoFileService:IVideoFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IVideoInfoRepository _videoInfoRepository;

        public VideoFileService(IWebHostEnvironment webHostEnvironment, IVideoInfoRepository videoInfoRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _videoInfoRepository = videoInfoRepository;
        }
        public async Task<IEnumerable<FileInfoViewModel>> GetAllVideoFiles()
        {
            var dir = Directory.CreateDirectory(Path.Combine(_webHostEnvironment.WebRootPath, "videos"));
            var files = dir.GetFiles("*.m4v", SearchOption.AllDirectories);
            var models = files.Select(fi => new FileInfoViewModel
            {
                Extension = fi.Extension,
                Path = Path.GetRelativePath(_webHostEnvironment.WebRootPath, fi.FullName),
                Name = fi.Name
            });
            return await Task.FromResult(models);
        }

        public async Task<IEnumerable<FileInfoViewModel>> GetUnmappedVideoFiles()
        {
            var allFiles = await GetAllVideoFiles();
            var toReturn = new List<FileInfoViewModel>();
            foreach (var fileInfo in allFiles)
            {
                if(await _videoInfoRepository.ContainsFilePathDefinition(fileInfo.Path))continue;
                toReturn.Add(fileInfo);
            }

            return toReturn;
        }
    }
}