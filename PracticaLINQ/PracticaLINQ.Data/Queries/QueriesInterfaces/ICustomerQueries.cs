using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System;
using System.Collections.Generic;

namespace PracticaLINQ.Data.Queries.QueriesInterfaces
{
    public interface ICustomerQueries
    {
        Customers GetOneCustomers();
        List<Customers> GetCustomersRegion(string custRegion);
        List<CustomersUpperLowerDTO> GetCustomersUpperLowers();
        List<CustomersOrdersDTO> GetCustomersOrders(string custRegion, DateTime date);
        List<Customers> GetCustomerCantByRegion(string custRegion, int cant);
        List<CustCantOrderDTO> GetCustCantOrder();
    }
}
