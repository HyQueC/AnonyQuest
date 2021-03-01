using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnonyQuest.Shared.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(int id);
        T Update(T entity);
        Task<IEnumerable<T>> AllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
