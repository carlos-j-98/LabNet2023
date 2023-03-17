using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Services.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PracticaLINQ.Services.Validatos
{
    public class CustomerValidator
    {
        public CustomerValidator()
        {

        }
        public bool IsNullCustomerValidator(Customers cust)
        {
            if (cust == null)
            {
                throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationCustText"]);
            }
            return true;
        }
        public bool IsNullListCustomerValidator(List<Customers> cust)
        {
            if (cust == null || cust.Count == 0)
            {
                throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationCustText"]);
            }
            return true;
        }
        public bool IsNullListCusCantOrderValidator(List<CustCantOrderDTO> cust)
        {
            if (cust == null || cust.Count == 0)
            {
                throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationCustText"]);
            }
            return true;
        }
        public bool IsNullListCusOrdersValidator(List<CustomersOrdersDTO> cust)
        {
            if (cust == null || cust.Count == 0)
            {
                throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationCustText"]);
            }
            return true;
        }
        public bool IsNullListCustomerUL(List<CustomersUpperLowerDTO> cust)
        {
            if (cust == null || cust.Count == 0)
            {
                throw new InvalidOperationException(ConfigurationManager.AppSettings["invalidOperationCustText"]);
            }
            return true;
        }
    }
}
