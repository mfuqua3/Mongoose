using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly MongooseContext _dbContext;

        public SeasonRepository(MongooseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Season>> GetAllSeasonsBySeries(int seriesId, QueryInject<Season> queryInject = null)
        {
            return await GetQuery(queryInject).Where(season => season.SeriesId == seriesId).ToListAsync();
        }

        public async Task<Season> GetSeason(int id, QueryInject<Season> queryInject = null)
        {
            return await GetQuery(queryInject).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task PostSeason(Season season)
        {
            await _dbContext.Seasons.AddAsync(season);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteSeason(int id)
        {
            var season = await GetSeason(id);
            if (season == null) return false;
            _dbContext.Seasons.Remove(season);
            return true;
        }

        private IQueryable<Season> GetQuery(QueryInject<Season> queryInject)
        {
            IQueryable<Season> query = _dbContext.Seasons;
            return queryInject == null ? query : queryInject(query);
        }
    }
}