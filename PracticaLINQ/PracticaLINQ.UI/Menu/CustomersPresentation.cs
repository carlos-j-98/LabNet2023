using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Logic.LogicBusiness;
using PracticaLINQ.Logic.LogicBusiness.LogicInterfaces;
using PracticaLINQ.Services.Validatos;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PracticaLINQ.UI.Menu
{
    public class CustomersPresentation
    {
        private readonly ICustomerLogic _customerService;
        private readonly CustomerValidator _customerValidator;
        public CustomersPresentation()
        {
            this._customerService = new CustomerLogic();
            this._customerValidator = new CustomerValidator();
        }
        public void WriteObjectCustomer()
        {
            Console.Clear();
            Console.Title = "Mostrar un customer";
            var save = _customerService.GetOneCustomer();
            if (_customerValidator.IsNullCustomerValidator(save))
            {
                Console.WriteLine("Se esta mostrando el primer customer que hay en la DB \n");
                Console.WriteLine($"Nombre de contacto: {save.ContactName} \n");
                Console.WriteLine($"Nombre de compania: {save.CompanyName} \n");
                Console.WriteLine($"Titulo de contacto: {save.ContactTitle} \n");
                Console.WriteLine($"Direccion: {save.Address} \n");
                Console.WriteLine($"Ciudad: {save.City} \n");
                Console.WriteLine($"Region: {save.Region} \n");
                Console.WriteLine($"Codigo postal: {save.PostalCode} \n");
                Console.WriteLine($"Country: {save.Country} \n");
                Console.WriteLine($"Telefono: {save.Phone} \n");
                Console.WriteLine($"Fax: {save.Fax} \n");
            }
        }
        public void WriteListCustomers(string select)
        {
            Console.Clear();
            string custRegion = ConfigurationManager.AppSettings["customerRegion"];
            Console.Title = $"Mostrar lista de Customers de {custRegion}";
            Console.Write($"Mostrando Customers de la region de {custRegion}");
            List<Customers> saveList;
            if (select == "puntoCuatro")
            {
                saveList = _customerService.GetCustomersRegion(custRegion);
            }
            else if (select == "puntoOcho")
            {
                int cantSelect = int.Parse(ConfigurationManager.AppSettings["cantSelect"]);
                saveList = _customerService.GetCustomersCantByRegion(custRegion, cantSelect);
            }
            else
            {
                MenuPrincipal.WriteIncorrectOption();
                return;
            }
            if (_customerValidator.IsNullListCustomerValidator(saveList))
            {
                foreach (var save in saveList)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Nombre de contacto: {save.ContactName}");
                    Console.WriteLine($"Nombre de compania: {save.CompanyName}");
                    Console.WriteLine($"Titulo de contacto: {save.ContactTitle}");
                    Console.WriteLine($"Direccion: {save.Address}");
                    Console.WriteLine($"Ciudad: {save.City}");
                    Console.WriteLine($"Region: {save.Region}");
                    Console.WriteLine($"Codigo postal: {save.PostalCode}");
                    Console.WriteLine($"Country: {save.Country}");
                    Console.WriteLine($"Telefono: {save.Phone}");
                    Console.WriteLine($"Fax: {save.Fax}");
                }
            }
        }
        public void WriteListCustomersUpperLowerDTO()
        {
            Console.Clear();
            Console.Title = "Mostrar lista de Customers en mayuscula y minuscula";
            Console.WriteLine("Lista de customers en mayuscula y en minuscula");
            var saveList = _customerService.GetCustomersUpperLowerCase();
            if (_customerValidator.IsNullListCustomerUL(saveList))
            {
                foreach (var save in saveList)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Nombre en minuscula: {save.lowerName}");
                    Console.WriteLine($"Nombre en mayuscula: {save.upperName}");
                }
            }
        }
        public void WriteListCustomerOrdersDTO()
        {
            Console.Clear();
            string custRegion = ConfigurationManager.AppSettings["customerRegion"];
            string year = ConfigurationManager.AppSettings["yearOrder"];
            string month = ConfigurationManager.AppSettings["monthOrder"];
            string day = ConfigurationManager.AppSettings["dayOrder"];
            string dateConcat = $"{day}/{month}/{year}";
            Console.Title = "Mostrando Customers y Orders";
            Console.WriteLine($"Lista de customers y orders de la region {custRegion} de la fecha {dateConcat} hasta hoy");
            var saveList = _customerService.GetCustomersOrdersRegionDate(custRegion, year, month, day);
            if (_customerValidator.IsNullListCusOrdersValidator(saveList))
            {
                foreach (var save in saveList)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Orden numero: {save.orderID}");
                    Console.WriteLine($"Nombre de contacto: {save.customerName}");
                    Console.WriteLine($"Region: {save.region}");
                    Console.WriteLine($"Direccion: {save.address},{save.city},{save.country}");
                    Console.WriteLine($"Codigo postal: {save.postalCode}");
                    Console.WriteLine($"Telefono: {save.phone}");
                    Console.WriteLine($"Fecha de orden: {save.orderDate}");
                }
            }
        }
        public void WriteCustCantOrderDTO()
        {
            Console.Clear();
            Console.Title = "Cantidad de ordenes por cada customer";
            Console.WriteLine("Cantidad de ordenes por customer \n");
            var saveList = _customerService.GetCustCantOrder();
            if (_customerValidator.IsNullListCusCantOrderValidator(saveList))
            {
                foreach (var item in saveList)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------- \n");
                    Console.WriteLine($"Nombre del customer: {item.custName}\n");
                    Console.WriteLine($"Lista de orders del customer: {item.asociedOrders} \n");
                    Console.WriteLine($"Cantidad de ordenes: {item.cantOrders} \n");
                }
            }
        }
    }
}
