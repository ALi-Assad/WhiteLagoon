using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class Repository<T>(ApplicationDbContext db): IRepository<T> where T : class
    {
        public DbSet<T> dbSet = db.Set<T>();

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        
        public bool Any(Expression<Func<T, bool>> filter)
        {
           return dbSet.Any(filter);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter,
           IEnumerable<Expression<Func<T, object>>>? expressions = null
            )
        {
            IQueryable<T> query = dbSet;

            if (filter is not null) { 
                query = query.Where(filter);
            }

            if (expressions is not null)
            {
                foreach (var expression in expressions)
                {
                   query = query.Include(expression);
                }
            }

            return query.ToList();
        }
    }
}
