using Practica4.EF.Data;
using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Logic.QueriesLogic
{
    public class ShippersLogic : GenericLogic <Shippers>
    {
        public override List<Shippers> GetAll()
        {
            using (_northwindContext)
            {
                return _northwindContext.Shippers.ToList();
            }
        }
        public Shippers GetById(int id)
        {
            using (_northwindContext)
            {
                var generic = _northwindContext.Shippers
                                .FirstOrDefault(_generic => _generic.ShipperID == id);
                return generic;
            }
        }
    }
}
