using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System.Collections.Generic;

namespace PracticaLINQ.Services.Service.ServicesInterfaces
{
    public interface ICustomerService
    {
        Customers GetOneCustomer();
        List<Customers> GetCustomersRegion(string custRegion);
        List<CustomersUpperLowerDTO> GetCustomersUpperLowerCase();
        List<CustomersOrdersDTO> GetCustomersOrdersRegionDate(string custRegion, string year, string month, string day);
        List<Customers> GetCustomersCantByRegion(string custRegion, int cant);
        List<CustCantOrderDTO> GetCustCantOrder();
    }
}
