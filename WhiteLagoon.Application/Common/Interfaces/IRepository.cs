using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, IEnumerable<Expression<Func<T, object>>>? expressions = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        bool Any(Expression<Func<T,bool>> filter);
        void Delete(T entity);
    }
}
