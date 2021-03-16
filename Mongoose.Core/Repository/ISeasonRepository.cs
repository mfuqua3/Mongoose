using System.Collections.Generic;
using System.Threading.Tasks;
using Mongoose.Core.Entities;

namespace Mongoose.Core.Repository
{
    public interface ISeasonRepository
    {
        Task<List<Season>> GetAllSeasonsBySeries(int seriesId, QueryInject<Season> queryInject = null);
        Task<Season> GetSeason(int id, QueryInject<Season> queryInject = null);
        Task PostSeason(Season season);
        Task SaveChanges();
        Task<bool> DeleteSeason(int id);
    }
}