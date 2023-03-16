using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ.Data.Queries.QueriesInterfaces
{
    public interface ICustomerQueries
    {
        Customers GetOneCustomers();
        List<Customers> GetCustomersRegionWA();
        List<CustomersUpperLowerDTO> GetCustomersUpperLowers();
        List<CustomersOrdersDTO> GetCustomersOrdersWA();
    }
}
