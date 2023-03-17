using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System.Collections.Generic;

namespace PracticaLINQ.Logic.LogicBusiness.LogicInterfaces
{
    public interface ICustomerLogic
    {
        Customers GetOneCustomer();
        List<Customers> GetCustomersRegion(string custRegion);
        List<CustomersUpperLowerDTO> GetCustomersUpperLowerCase();
        List<CustomersOrdersDTO> GetCustomersOrdersRegionDate(string custRegion, string year, string month, string day);
        List<Customers> GetCustomersCantByRegion(string custRegion, int cant);
        List<CustCantOrderDTO> GetCustCantOrder();
    }
}
