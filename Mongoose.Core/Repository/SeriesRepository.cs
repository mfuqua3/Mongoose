using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public class SeriesRepository:ISeriesRepository
    {
        private readonly MongooseContext _context;

        public SeriesRepository(MongooseContext context)
        {
            _context = context;
        }

        private IQueryable<Series> GetQuery(QueryInject<Series> queryInject)
        {
            IQueryable<Series> query = _context.Series;
            return queryInject == null ? query : queryInject(query);
        }
        public async Task<List<Series>> GetAllSeries(QueryInject<Series> queryInject = null)
        {
            return await GetQuery(queryInject).ToListAsync();
        }

        public async Task<Series> GetSeriesByName(string name, QueryInject<Series> queryInject = null)
        {
            return await GetQuery(queryInject).FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<Series> GetSeriesById(int id, QueryInject<Series> queryInject = null)
        {
            return await GetQuery(queryInject).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task PostSeries(Series series)
        {
            await _context.AddAsync(series);
        }

        public async Task<bool> DeleteSeries(int id)
        {
            var series = await GetSeriesById(id);
            if (series == null) return false;
            _context.Series.Remove(series);
            return true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}