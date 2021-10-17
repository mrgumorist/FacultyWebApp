using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWebApp.DAL.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(Guid id);
        T GetById(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllIQueryable();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        public void Update(T entity);
    }
}
