using System.Data.Entity.Migrations;

namespace Practica4.EF.Data.Repositorys
{
    public class Repository : IRepository
    {
        private readonly NorthwindContext dbContext;
        public Repository()
        {
            this.dbContext = new NorthwindContext();
        }
        public Repository(NorthwindContext context)
        {
            this.dbContext = context;
        }
        public void Add<T>(T entity) where T : class
        {
            var _dbSet = dbContext.Set<T>();
            _dbSet.Add(entity);
            dbContext.SaveChanges();
        }
        public void Update<T>(T entity) where T : class
        {
            var _dbSet = dbContext.Set<T>();
            _dbSet.AddOrUpdate(entity);
            dbContext.SaveChanges();
        }
        public void Delete<T>(int id) where T : class
        {
            var _dbSet = dbContext.Set<T>();
            _dbSet.Remove(_dbSet.Find(id));
            dbContext.SaveChanges();
        }
        public void Delete<T>(string id) where T : class
        {
            var _dbSet = dbContext.Set<T>();
            _dbSet.Remove(_dbSet.Find(id));
            dbContext.SaveChanges();
        }
    }
}
