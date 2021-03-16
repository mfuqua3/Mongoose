using System.Collections.Generic;
using System.Threading.Tasks;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public interface IEpisodeRepository
    {
        Task<List<Episode>> GetAllEpisodesBySeason(int seasonId);
        Task<List<Episode>> GetAllEpisodesBySeries(int seriesId);
        Task<Episode> GetEpisode(int id);
        Task PostEpisode(Episode episode);
        Task SaveChanges();
        Task<bool> DeleteEpisode(int id);
    }
}