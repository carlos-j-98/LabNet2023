using PracticaLINQ.Data.Context;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ.Data.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly NorthwindContext _northwindContext;
        public CustomerQueries()
        {
            _northwindContext = new NorthwindContext();            
        }

        public List<CustomersOrdersDTO> GetCustomersOrdersWA()
        {
            var custOrders = from c in _northwindContext.Customers
                             join o in _northwindContext.Orders on c.CustomerID equals o.CustomerID
                             where c.Region == "WA" && o.OrderDate > new DateTime(1997, 1, 1)
                             select new CustomersOrdersDTO
                             {
                                 region = c.Region,
                                 orderDate = o.RequiredDate,
                                 contactName = c.ContactName
                             };
            return custOrders.ToList();
        }

        public List<Customers> GetCustomersRegionWA()
        {
            return _northwindContext.Customers.Where(x => x.Region == "WA").ToList();
        }

        public List<CustomersUpperLowerDTO> GetCustomersUpperLowers()
        {
            var customersName = from c in _northwindContext.Customers
                                select new CustomersUpperLowerDTO
                                {
                                    idCustomer = c.CustomerID,
                                    lowerName = c.ContactName,
                                    upperName = c.ContactName
                                };
            return customersName.ToList();
        }

        public Customers GetOneCustomers()
        {
            return _northwindContext.Customers.FirstOrDefault();
        }
    }
}
