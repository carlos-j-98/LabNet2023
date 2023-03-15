using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Data.Queries
{
    public class ShipperQueries : IShipperQueries
    {
        private readonly NorthwindContext _context;
        public ShipperQueries()
        {
            _context = new NorthwindContext();
        }
        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }

        public Shippers GetById(int id)
        {
            return _context.Shippers.Find(id);
        }
    }
}
