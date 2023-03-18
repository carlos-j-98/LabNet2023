﻿using PracticaLINQ.Data.Queries;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Logic.LogicBusiness.LogicInterfaces;
using System;
using System.Collections.Generic;

namespace PracticaLINQ.Logic.LogicBusiness
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerQueries _customerQueries;
        public CustomerLogic()
        {
            this._customerQueries = new CustomerQueries();
        }
        public CustomerLogic(ICustomerQueries customerQueries)
        {
            _customerQueries = customerQueries;
        }

        public List<CustCantOrderDTO> GetCustCantOrder()
        {
            return _customerQueries.GetCustCantOrder();
        }

        public List<Customers> GetCustomersCantByRegion(string custRegion, int cant)
        {
            return _customerQueries.GetCustomerCantByRegion(custRegion, cant);
        }

        public List<CustomersOrdersDTO> GetCustomersOrdersRegionDate(string custRegion, string year, string month, string day)
        {
            DateTime date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            return _customerQueries.GetCustomersOrders(custRegion, date);
        }
        public List<Customers> GetCustomersRegion(string custRegion)
        {
            return _customerQueries.GetCustomersRegion(custRegion);
        }

        public List<CustomersUpperLowerDTO> GetCustomersUpperLowerCase()
        {
            return _customerQueries.GetCustomersUpperLowers();
        }

        public Customers GetOneCustomer()
        {
            return _customerQueries.GetOneCustomers();
        }
    }
}
