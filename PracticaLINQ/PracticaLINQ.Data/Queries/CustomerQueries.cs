using PracticaLINQ.Data.Context;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Services.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PracticaLINQ.Data.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly NorthwindContext _northwindContext;
        public CustomerQueries()
        {
            _northwindContext = new NorthwindContext();
        }
        public List<CustCantOrderDTO> GetCustCantOrder()
        {
            var custOrder = (from o in _northwindContext.Orders
                             join c in _northwindContext.Customers on o.CustomerID equals c.CustomerID
                             group o by c.ContactName into g
                             select new
                             {
                                 custNames = g.Key,
                                 lOrders = g.Select(p => p.OrderID).ToList()
                             }).ToList();
            var result = custOrder
                .ToList()
                .Select(x => new CustCantOrderDTO
                {
                    custName = x.custNames,
                    asociedOrders = string.Join(",", x.lOrders),
                    cantOrders = x.lOrders.Count
                }).ToList();
            return result ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationCustText"]);
        }

        public List<Customers> GetCustomerCantByRegion(string custRegion, int cant)
        {
            var customers = (from c in _northwindContext.Customers
                             where c.Region == custRegion
                             select c).Take(cant).ToList();
            return customers ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public List<CustomersOrdersDTO> GetCustomersOrders(string custRegion, DateTime date)
        {
            var custOrders = from c in _northwindContext.Customers
                             join o in _northwindContext.Orders on c.CustomerID equals o.CustomerID
                             where c.Region == "WA" && o.OrderDate > new DateTime(1997, 1, 1)
                             select new CustomersOrdersDTO
                             {
                                 region = c.Region,
                                 orderDate = o.RequiredDate,
                                 customerName = c.ContactName,
                                 shippDate = o.ShippedDate,
                                 requiredDate = o.RequiredDate,
                                 freight = o.Freight,
                                 address = c.Address,
                                 city = c.City,
                                 postalCode = c.PostalCode,
                                 country = c.Country,
                                 phone = c.Phone,
                                 orderID = o.OrderID
                             };
            return custOrders
                .ToList() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public List<Customers> GetCustomersRegion(string custRegion)
        {
            return _northwindContext.Customers
                .Where(x => x.Region == custRegion)
                .ToList() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public List<CustomersUpperLowerDTO> GetCustomersUpperLowers()
        {
            var customersName = from c in _northwindContext.Customers
                                select new CustomersUpperLowerDTO
                                {
                                    lowerName = c.ContactName.ToLower(),
                                    upperName = c.ContactName.ToUpper()
                                };
            return customersName
                .ToList() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public Customers GetOneCustomers()
        {
            return _northwindContext.Customers
                .FirstOrDefault() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }
    }
}
