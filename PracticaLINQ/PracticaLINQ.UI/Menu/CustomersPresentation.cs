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
                Console.WriteLine($"Titulo de contacto: {save.ContactTitle ?? "Desconocido"} \n");
                Console.WriteLine($"Direccion: {save.Address ?? "Desconocido"} \n");
                Console.WriteLine($"Ciudad: {save.City ?? "Desconocido"} \n");
                Console.WriteLine($"Region: {save.Region ?? "Desconocido"} \n");
                Console.WriteLine($"Codigo postal: {save.PostalCode ?? "Desconocido"} \n");
                Console.WriteLine($"Country: {save.Country ?? "Desconocido"} \n");
                Console.WriteLine($"Telefono: {save.Phone ?? "Desconocido"} \n");
                Console.WriteLine($"Fax: {save.Fax ?? "Desconocido"} \n");
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
                    Console.WriteLine($"Nombre de contacto: {save.ContactName ?? "Desconocido"}");
                    Console.WriteLine($"Nombre de compania: {save.CompanyName}");
                    Console.WriteLine($"Titulo de contacto: {save.ContactTitle ?? "Desconocido"}");
                    Console.WriteLine($"Direccion: {save.Address ?? "Desconocido"}");
                    Console.WriteLine($"Ciudad: {save.City ?? "Desconocido"}");
                    Console.WriteLine($"Region: {save.Region ?? "Desconocido"}");
                    Console.WriteLine($"Codigo postal: {save.PostalCode ?? "Desconocido"}");
                    Console.WriteLine($"Country: {save.Country ?? "Desconocido"}");
                    Console.WriteLine($"Telefono: {save.Phone ?? "Desconocido"}");
                    Console.WriteLine($"Fax: {save.Fax ?? "Desconocido"}");
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
                    Console.WriteLine($"Nombre en minuscula: {save.lowerName ?? "Desconocido"}");
                    Console.WriteLine($"Nombre en mayuscula: {save.upperName ?? "Desconocido"}");
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
                    Console.WriteLine($"Orden numero: {save.orderID.ToString() ?? "Desconocido"}");
                    Console.WriteLine($"Nombre de contacto: {save.customerName ?? "Desconocido"}");
                    Console.WriteLine($"Region: {save.region ?? "Desconocido"}");
                    Console.WriteLine($"Direccion: {save.address + "," +save.city + "," +save.country ?? "Desconocido"}");
                    Console.WriteLine($"Codigo postal: {save.postalCode ?? "Desconocido"}");
                    Console.WriteLine($"Telefono: {save.phone ?? "Desconocido"}");
                    Console.WriteLine($"Fecha de orden: {save.orderDate.ToString() ?? "Desconocido"}");
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
                    Console.WriteLine($"Nombre del customer: {item.custName ?? "Desconocido"}\n");
                    Console.WriteLine($"Lista de orders del customer: {item.asociedOrders ?? "Desconocido"} \n");
                    Console.WriteLine($"Cantidad de ordenes: {item.cantOrders.ToString() ?? "Desconocido"} \n");
                }
            }
        }
    }
}
