using System.Linq;

namespace Mongoose.Core.Repository
{
    public delegate IQueryable<T> QueryInject<T>(IQueryable<T> queryable) where T : class;
}