using System.Collections.Generic;
using System.Threading.Tasks;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public interface ISeriesRepository
    {
        Task<List<Series>> GetAllSeries(QueryInject<Series> queryInject = null);
        Task<Series> GetSeriesByName(string name, QueryInject<Series> queryInject = null);
        Task<Series> GetSeriesById(uint id, QueryInject<Series> queryInject = null);
        Task PostSeries(Series series);
        Task SaveChanges();
    }
}