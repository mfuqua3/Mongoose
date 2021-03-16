using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly MongooseContext _dbContext;

        public EpisodeRepository(MongooseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Episode>> GetAllEpisodesBySeason(int seasonId)
        {
            return await _dbContext.Episodes.Include(e => e.VideoInfo).Where(e => e.SeasonId == seasonId).ToListAsync();
        }

        public async Task<List<Episode>> GetAllEpisodesBySeries(int seriesId)
        {
            return await _dbContext.Episodes
                .Include(e => e.VideoInfo)
                .Include(e => e.Season)
                .Where(e => e.Season.SeriesId == seriesId)
                .ToListAsync();
        }

        public async Task<Episode> GetEpisode(int id)
        {
            return await _dbContext.Episodes.Include(e => e.VideoInfo).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task PostEpisode(Episode episode)
        {
            await _dbContext.Episodes.AddAsync(episode);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteEpisode(int id)
        {
            var episode = await GetEpisode(id);
            if (episode == null) return false;
            _dbContext.Remove(episode);
            return true;
        }
    }
}