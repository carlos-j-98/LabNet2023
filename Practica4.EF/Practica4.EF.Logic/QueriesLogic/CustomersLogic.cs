using Practica4.EF.Data;
using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Logic.QueriesLogic
{
    public class CustomersLogic : GenericLogic <Customers>
    {
        public override List<Customers> GetAll()
        {
            using (_northwindContext) 
            {
                return _northwindContext.Customers.ToList();
            }
        }
    }
}
