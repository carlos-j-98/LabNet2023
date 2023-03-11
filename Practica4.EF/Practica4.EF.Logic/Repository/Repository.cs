using Practica4.EF.Data;
using System.Data.Entity;

namespace Practica4.EF.Logic.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NorthwindContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository()
        {
            this._context = new NorthwindContext();
            this._dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int _id)
        {
            _dbSet.Remove(_dbSet.Find(_id));
            _context.SaveChanges();
        }
    }
}
