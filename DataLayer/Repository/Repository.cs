using CoreLayer.Interfaces;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet; //context.Futbolcus

            if (predicate != null)
            {
                query = query.Where(predicate); //context.Futbolcus.Where(x=>x.FultbolcuId>);
            }

            if (include != null)
            {
                query = include(query);//context.Futbolcus.Include(x=>x.Team).Where(x=>x.FultbolcuId>0);
            }


            return query.AsNoTracking().AsQueryable();
        }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
