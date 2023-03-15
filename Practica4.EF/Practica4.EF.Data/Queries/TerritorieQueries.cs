using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Data.Queries
{
    public class TerritorieQueries : ITerritoriesQueries
    {
        private readonly NorthwindContext _dbContext;
        public TerritorieQueries()
        {
            _dbContext = new NorthwindContext();
        }
        public TerritorieQueries(NorthwindContext context)
        {
            _dbContext = context;
        }
        public List<Territories> GetAll()
        {
            return _dbContext.Territories.ToList();
        }

        public Territories GetById(string id)
        {
            return _dbContext.Territories.Find(id);
        }
    }
}
