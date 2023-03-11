using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.QueriesLogic;
using Practica4.EF.Logic.QueriesLogic.GenericQuerieLogic;
using Practica4.EF.Logic.Repository;
using System;
using System.Linq;

namespace Practica4.EF.UI.Menu
{
    public class MenuRepositorio
    {
        public MenuRepositorio()
        {

        }
        public static void RunMenuRepositorio()
        {
            WriteMenuRepositorio();
            switch (MenuPrincipal.SelectOption())
            {
                case 1:
                    WriteAddShippers();
                    break;
                case 2:
                    WriteUpdateShippers();
                    break;
                case 3:
                    WriteDelete();
                    break;
                default:
                    MenuPrincipal.WriteIncorrectOption();
                    RunMenuRepositorio();
                    break;
            }
        }
        public static void WriteMenuRepositorio()
        {
            Console.Clear();
            Console.Title = "Menu repositorio";
            Console.WriteLine("Bienvenido al menu repositorio \n");
            Console.WriteLine("¿Que desea hacer? \n");
            Console.WriteLine("1- Agregar un -Shippers- a la DB \n");
            Console.WriteLine("2- Actualizar un -Shippers- a la DB \n");
            Console.WriteLine("3- Borrar un -Shippers- de la DB \n");
            Console.WriteLine("4- Volver al menu principal \n");
        }
        public static void WriteAddShippers()
        {
            Console.Clear();
            Console.Title = "Menu de agregar a DB";
            Console.WriteLine("Ingresa los datos que se pidan para poder agregar un -Shippers- a la DB \n");
            Console.WriteLine("Ingresa un nombre para la compania \n");
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Ingresa un numero de telefono para la compania \n");
            Console.Write("Telefono: ");
            string number = Console.ReadLine();
            Shippers shipper = new Shippers()
            {
                CompanyName = name,
                Phone = number
            };
            var repository = new Repository<Shippers>();
            repository.Add(shipper);
            Console.WriteLine(shipper.ShipperID);
            Console.ReadKey();
        }
        public static void WriteUpdateShippers()
        {
            Console.Clear();
            Console.Title = "Menu de actualizar la DB";
            Console.WriteLine("Ingresa los datos que se pidan para poder actualizar un -Shippers- a la DB \n");
            GenericLogic genericLogic = new ShippersLogic();
            var saveList = genericLogic.GetAll();
            MenuConsultas.WriteInfoList(saveList);
            Console.WriteLine("Ingrese el ID para modificar sus datos \n");
            int select = MenuPrincipal.SelectOption();
            foreach (var item in saveList)
            {
                if (int.Parse(item.id) == select) 
                {
                    WriteChangeValues(item, select);
                    break;
                }
            }
        }
        public static void WriteInfoUnit(GenericDTO generic)
        {
            Console.WriteLine("---------------------------- \n");
            Console.WriteLine($"ID: {generic.id} \n");
            Console.WriteLine($"Descripcion: {generic.description} \n");
        }
        public static void WriteChangeValues(GenericDTO saveObject,int select)
        {
            Console.Clear();
            ShippersLogic shippersLogic = new ShippersLogic();
            Shippers shippers = shippersLogic.GetById(select);
            Console.WriteLine("Actual \n");
            WriteInfoUnit(saveObject);
            Console.WriteLine("Ingrese nuevos datos \n");
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Telefono: ");
            string number = Console.ReadLine();
            shippers.CompanyName = name;
            shippers.Phone = number;
            var repository = new Repository<Shippers>();
            repository.Update(shippers);
            Console.WriteLine("Cambios realizados con exito \n");
        }
        public static void WriteDelete() 
        {
            Console.Clear();
            Console.Title = "Menu de borrado ";
            Console.WriteLine("Bienvenido al menu de borrar elementos -Shippers-");
            ShippersLogic genericLogic = new ShippersLogic();
            var saveList = genericLogic.GetAll();
            MenuConsultas.WriteInfoList(saveList);
            Console.WriteLine("Ingrese el ID del elemento que desea borrar \n");
            int select = MenuPrincipal.SelectOption();
            foreach (var item in saveList)
            {
                if (int.Parse(item.id) == select)
                {
                    WriteConfirmDelete(item);
                    break;
                }
            }


        }
        public static void WriteConfirmDelete(GenericDTO genericDTO) 
        {
            Console.Clear();
            Console.Title = "Confirmar borrado";
            Console.WriteLine("Este es el elemento que esta intentando borrar \n");
            WriteInfoUnit(genericDTO);
            Console.WriteLine("¿Confimar borrado? \n");
            Console.WriteLine("1- Si \n");
            Console.WriteLine("2- No \n");
            if (MenuPrincipal.SelectOption() == 1) 
            {
                Repository<Shippers> repository = new Repository<Shippers>();
                repository.Delete(int.Parse(genericDTO.id));
                Console.WriteLine("Borrado realizado con exito \n");
                Console.ReadKey();
            }
        }
    }
}
