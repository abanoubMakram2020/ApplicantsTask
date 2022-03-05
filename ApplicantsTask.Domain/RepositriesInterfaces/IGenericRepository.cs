using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantsTask.Domain.RepositriesInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        IQueryable<T> Get(Expression<Func<T, bool>> expression = null, string includes = "");
        Task Add(T entity);
        Task Add(List<T> entities);

        void Delete(T entity);
        void Delete(List<T> entities);
        void Update(T entity);
        void Update(List<T> entities);

    }
}
