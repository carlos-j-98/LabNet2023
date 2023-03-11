using Practica4.EF.Data;
using Practica4.EF.Entities.DTO;
using Practica4.EF.Logic.QueriesLogic.GenericQuerieLogic;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Logic.QueriesLogic
{
    public class CustomersLogic : GenericLogic
    {

        public override List<GenericDTO> GetAll()
        {
            using (var context = new NorthwindContext())
            {
                var generic = context.Customers
                                .Select(_generic => new GenericDTO
                                {
                                    id = _generic.CustomerID.ToString(),
                                    description = _generic.CompanyName
                                }).ToList();
                return generic;
            }
        }
    }
}
