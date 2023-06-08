using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace services.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter);
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
