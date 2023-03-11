using Practica4.EF.Entities.DTO;
using Practica4.EF.Logic.QueriesLogic;
using Practica4.EF.Logic.QueriesLogic.GenericQuerieLogic;
using System;
using System.Collections.Generic;

namespace Practica4.EF.UI.Menu
{
    public class MenuConsultas
    {
        public MenuConsultas()
        {

        }
        public static void RunMenuConsultas()
        {
            WriteMenuConsultas();
            GenericLogic genericLogic;
            switch (MenuPrincipal.SelectOption())
            {
                case 1:
                    genericLogic = new CategoriesLogic();
                    break;
                case 2:
                    genericLogic = new CustomersLogic();
                    break;
                case 3:
                    genericLogic = new ShippersLogic();
                    break;
                case 4:
                    genericLogic = new TerritoriesLogic();
                    break;
                case 5:
                    return;
                default:
                    MenuPrincipal.WriteIncorrectOption();
                    RunMenuConsultas();
                    genericLogic = new CategoriesLogic();
                    break;
            }
            WriteInfoList(genericLogic.GetAll());
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
        public static void WriteOptionsToBack()
        {
            Console.WriteLine("");

        }
        public static void WriteInfoList(List<GenericDTO> genericDTOs)
        {
            Console.Clear();
            Console.Title = "Mostrando datos";
            foreach (var item in genericDTOs)
            {
                Console.WriteLine("---------------------------- \n");
                Console.WriteLine($"ID: {item.id} \n");
                Console.WriteLine($"ID: {item.description} \n");
            }
        }
    }
}
