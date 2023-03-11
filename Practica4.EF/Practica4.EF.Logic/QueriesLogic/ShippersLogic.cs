using Practica4.EF.Data;
using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.QueriesLogic.GenericQuerieLogic;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Logic.QueriesLogic
{
    public class ShippersLogic : GenericLogic
    {
        public override List<GenericDTO> GetAll()
        {
            using (var context = new NorthwindContext())
            {
                var generic = context.Shippers
                                .Select(_generic => new GenericDTO
                                {
                                    id = _generic.ShipperID.ToString(),
                                    description = _generic.CompanyName
                                }).ToList();
                return generic;
            }
        }
        public Shippers GetById(int id)
        {
            using (var context = new NorthwindContext())
            {
                var generic = context.Shippers
                                .FirstOrDefault(_generic => _generic.ShipperID == id);
                return generic;
            }
        }
    }
}
