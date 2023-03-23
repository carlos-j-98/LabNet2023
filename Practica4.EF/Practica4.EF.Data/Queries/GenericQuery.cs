using Practica4.EF.Data.Queries.InterfaceQueries;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Data.Queries
{
    public class GenericQuery : IGenericQuerie
    {
        private readonly NorthwindContext _context;
        public GenericQuery()
        {
            _context = new NorthwindContext();
        }
        public List<T> GetAll<T>() where T : class
        {
            var _dbSet = _context.Set<T>();
            return _dbSet.ToList();
        }

        public T GetById<T>(string id) where T : class
        {
            var _dbSet = _context.Set<T>();
            return _dbSet.Find(id);
        }
        public T GetById<T>(int id) where T : class
        {
            var _dbSet = _context.Set<T>();
            return _dbSet.Find(id);
        }
    }
}
