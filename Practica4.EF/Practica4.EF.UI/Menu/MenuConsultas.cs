using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Services;
using Practica4.EF.Services.CustomExceptions;
using Practica4.EF.Services.InterfaceService;
using System;
using System.Collections.Generic;

namespace Practica4.EF.UI.Menu
{
    public class MenuConsultas
    {
        private readonly IShipperService _shipperService;
        private readonly ITerritorieService _territorieService;
        public MenuConsultas()
        {
            _shipperService = new ShipperService();
            _territorieService = new TerritorieService();
        }
        public void RunMenuConsultas()
        {
            WriteMenuConsultas();
            try
            {
                switch (MenuPrincipal.SelectOption())
                {
                    case 1:
                        WriteInfoShippersList(_shipperService.GetAll());
                        break;
                    case 2:
                        WriteInfoTerritoriesList(_territorieService.GetAll());
                        break;
                    case 3:
                        return;
                    default:
                        MenuPrincipal.WriteIncorrectOption();
                        RunMenuConsultas();
                        return;
                }
            }
            catch (IsNullException ex)
            {
                MenuPrincipal.WriteExceptionInfo(ex);
                MenuPrincipal.WriteBackMenu();
            }
        }
        public static void WriteMenuConsultas()
        {
            Console.Clear();
            Console.Title = "Menu consultas";
            Console.WriteLine("Bienvenido al menu de consultas a la DB \n");
            Console.WriteLine("¿Que datos desea obtener? \n");
            Console.WriteLine("1- Shippers \n");
            Console.WriteLine("2- Territories \n");
            Console.WriteLine("3- Volver al menu principal. \n");
        }
        public static void WriteInfoShippersList(List<Shippers> ship)
        {
            Console.Clear();
            if (ship.Count == 0) 
            {
                throw new IsNullException();
            }
            else 
            {
                foreach (var shippers in ship)
                {
                    Console.WriteLine("---------------------------- \n");
                    Console.WriteLine($"ID: {shippers.ShipperID}");
                    Console.WriteLine($"Nombre de empresa: {shippers.CompanyName}");
                    Console.WriteLine($"Telefono: {shippers.Phone}");
                }
            }

        }
        public static void WriteInfoTerritoriesList(List<Territories> terri)
        {
            Console.Clear();
            if (terri.Count == 0) 
            {
                throw new IsNullException();
            }
            else 
            {
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
}
