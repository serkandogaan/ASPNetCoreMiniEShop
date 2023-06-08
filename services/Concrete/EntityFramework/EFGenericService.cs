using Microsoft.EntityFrameworkCore;
using services.Abstract;
using System.Linq.Expressions;


namespace services.Concrete.EntityFramework
{
    public class EFGenericService<T> : IGenericService<T> where T : class
    {
        protected readonly DbContext _context;
        public EFGenericService(DbContext context)
        {
            _context = context;

        }     
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Set<T>().Find(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

    }
}
