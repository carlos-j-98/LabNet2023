using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.QueriesLogic;
using System;
using System.Collections.Generic;

namespace Practica4.EF.UI.Menu
{
    public class MenuConsultas
    {
        public MenuConsultas() 
        {
        }
        public void RunMenuConsultas()
        {
            WriteMenuConsultas();
            switch (MenuPrincipal.SelectOption())
            {
                case 1:
                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                    WriteInfoCategoriesList(categoriesLogic.GetAll());
                    break;
                case 2:
                    CustomersLogic customersLogic = new CustomersLogic();
                    WriteInfoCustomersList(customersLogic.GetAll());
                    break;
                case 3:
                    ShippersLogic shippersLogic = new ShippersLogic();
                    WriteInfoShippersList(shippersLogic.GetAll());
                    break;
                case 4:
                    TerritoriesLogic territoriesLogic = new TerritoriesLogic();
                    WriteInfoTerritoriesList(territoriesLogic.GetAll());
                    break;
                case 5:
                    return;
                default:
                    MenuPrincipal.WriteIncorrectOption();
                    RunMenuConsultas();
                    return;
            }
        }
        public static void WriteMenuConsultas()
        {
            Console.Clear();
            Console.Title = "Menu consultas";
            Console.WriteLine("Bienvenido al menu de consultas a la DB \n");
            Console.WriteLine("¿Que datos desea obtener? \n");
            Console.WriteLine("1- Categories \n");
            Console.WriteLine("2- Customers \n");
            Console.WriteLine("3- Shippers \n");
            Console.WriteLine("4- Territories \n");
            Console.WriteLine("5- Volver al menu principal. \n");
        }
        public static void WriteInfoCategoriesList(List<Categories> cat) 
        {
            Console.Clear();
            foreach (var categories in cat)
            {
                Console.WriteLine("---------------------------- \n");
                Console.WriteLine($"ID: {categories.CategoryID}");
                Console.WriteLine($"Nombre categoria: {categories.CategoryName}");
                Console.WriteLine($"Descripcion: {categories.Description}");
            }
        }
        public static void WriteInfoCustomersList(List<Customers> cust) 
        {
            Console.Clear();
            foreach (var customers in cust)
            {
                Console.WriteLine("---------------------------- \n");
                Console.WriteLine($"ID: {customers.CustomerID}");
                Console.WriteLine($"Nombre de empresa: {customers.CompanyName}");
                Console.WriteLine($"Contacto: {customers.ContactName}");
                Console.WriteLine($"Titulo de contacto: {customers.ContactTitle}");
                Console.WriteLine($"Direccion: {customers.Address}");
                Console.WriteLine($"Ciudad: {customers.City}");
                Console.WriteLine($"Region: {customers.Region}");
                Console.WriteLine($"Codigo postal: {customers.PostalCode}");
                Console.WriteLine($"Telefono: {customers.Phone}");
                Console.WriteLine($"Fax: {customers.Fax}");
            }

        }
        public static void WriteInfoShippersList(List<Shippers> ship) 
        {
            Console.Clear();
            foreach (var shippers in ship)
            {
                Console.WriteLine("---------------------------- \n");
                Console.WriteLine($"ID: {shippers.ShipperID}");
                Console.WriteLine($"Nombre de empresa: {shippers.CompanyName}");
                Console.WriteLine($"Telefono: {shippers.Phone}");
            }
        }
        public static void WriteInfoTerritoriesList(List<Territories> terri) 
        {
            Console.Clear();
            foreach (var territories in terri)
            {
                Console.WriteLine("---------------------------- \n");
                Console.WriteLine($"ID: {territories.TerritoryID}");
                Console.WriteLine($"Descripcion: {territories.TerritoryDescription}");
                Console.WriteLine($"ID de region: {territories.RegionID}");
            }
        }
    }
}
