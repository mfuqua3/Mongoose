using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public class VideoInfoRepository : IVideoInfoRepository
    {
        private readonly MongooseContext _context;

        public VideoInfoRepository(MongooseContext context)
        {
            _context = context;
        }
        public async Task<bool> ContainsFilePathDefinition(string filePath)
        {
            return await _context.VideoInfo.AnyAsync(vi => vi.FilePath == filePath);
        }

        public async Task<VideoInfo> GetVideoInfo(int id)
        {
            return await _context.VideoInfo.FindAsync(id);
        }
    }
}