using KatmanliSinavProject.Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.Core.Repositories
{
    public interface IBaseRepository<T> where T : class,IBaseEntity
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        bool Any(Expression<Func<T, bool>> expression);
        IList<T> GetAll();
        IList<T> GetNotPassives();
        T GetDefault(Expression<Func<T, bool>> expression);
        IList<T> GetAllDefaults(Expression<Func<T, bool>> expression);
    }
}
