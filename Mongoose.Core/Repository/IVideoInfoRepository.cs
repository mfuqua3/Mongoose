using System.Threading.Tasks;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public interface IVideoInfoRepository
    {
        Task<bool> ContainsFilePathDefinition(string filePath);
        Task<VideoInfo> GetVideoInfo(int id);
    }
}