using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
   public interface IService<T> where T:class
    {
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
    }
}
