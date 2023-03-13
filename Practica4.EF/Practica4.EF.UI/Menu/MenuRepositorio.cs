using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.QueriesLogic;
using Practica4.EF.Logic.Repository;
using Practica4.EF.Logic.Validators;
using System;
using System.Collections.Generic;

namespace Practica4.EF.UI.Menu
{
    public class MenuRepositorio
    {
        private readonly ShippersValidator _shippersValidator;
        public MenuRepositorio()
        {
            _shippersValidator = new ShippersValidator();
        }
        public void RunMenuRepositorio()
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
        public void WriteAddShippers()
        {
            Console.Clear();
            Console.Title = "Menu de agregar a DB";
            Console.WriteLine("Ingresa los datos que se pidan para poder agregar un -Shippers- a la DB \n");
            Console.WriteLine("Ingresa un nombre para la compania \n");
            string name = WriteInsert("Nombre");
            Console.WriteLine("");
            Console.WriteLine("Ingresa un numero de telefono para la compania \n");
            string number = WriteInsert("Numero");
            Console.WriteLine("");
            Console.WriteLine("La -Shipper- fue creada con el ID: {0} \n", AddShippers(name, number));
        }
        public int AddShippers(string name, string number)
        {
            Shippers shipper = new Shippers()
            {
                CompanyName = name,
                Phone = number
            };
            Repository<Shippers> repository = new Repository<Shippers>();
            repository.Add(shipper);
            return shipper.ShipperID;
        }
        public void WriteUpdateShippers()
        {
            Console.Clear();
            Console.Title = "Menu de actualizar la DB";
            Console.WriteLine("Ingresa los datos que se pidan para poder actualizar un -Shipper- de la DB \n");
            ShippersLogic shippersLogic = new ShippersLogic();
            List<Shippers> saveList = shippersLogic.GetAll();
            MenuConsultas.WriteInfoShippersList(saveList);
            Console.WriteLine("");
            Console.WriteLine("Ingrese el ID de la -Shipper- que quiera modificar sus datos \n");
            int select = MenuPrincipal.SelectOption();
            Shippers ship = _shippersValidator.ShipperExist(saveList, select);
            if (ship != null)
            {
                WriteChangeValues(ship);
            }
            else
            {
                Console.WriteLine("No se encontro ningun shipper con el ID: {0} \n", select);
            }
        }
        public void WriteChangeValues(Shippers shipp)
        {
            Console.Clear();
            Console.WriteLine("Actual \n");
            WriteInfoShipperUnit(shipp);
            Console.WriteLine("Ingrese nuevos datos \n");
            string name = WriteInsert("Nombre");
            Console.WriteLine("");
            string number = WriteInsert("Telefono");
            UpdateShipper(name, number, shipp);
            Console.WriteLine("");
            Console.WriteLine("Cambios realizados con exito \n");
        }
        public static void WriteInfoShipperUnit(Shippers shippers)
        {
            Console.WriteLine("---------------------------- \n");
            Console.WriteLine($"ID: {shippers.ShipperID}");
            Console.WriteLine($"Nombre de empresa: {shippers.CompanyName}");
            Console.WriteLine($"Telefono: {shippers.Phone}");
            Console.WriteLine("---------------------------- \n");
        }
        public void UpdateShipper(string name, string number, Shippers ship)
        {
            ship.CompanyName = name;
            ship.Phone = number;
            Repository<Shippers> repository = new Repository<Shippers>();
            repository.Update(ship);
        }
        public void WriteDelete()
        {
            Console.Clear();
            Console.Title = "Menu de borrado ";
            Console.WriteLine("Bienvenido al menu de borrar elementos -Shippers- \n");
            ShippersLogic shippersLogic = new ShippersLogic();
            List<Shippers> saveList = shippersLogic.GetAll();
            MenuConsultas.WriteInfoShippersList(saveList);
            Console.WriteLine("");
            Console.WriteLine("Ingrese el ID del elemento que desea borrar \n");
            int select = MenuPrincipal.SelectOption();
            Shippers ship = _shippersValidator.ShipperExist(saveList, select);
            if (ship != null)
            {
                WriteConfirmDelete(ship);
            }
            else
            {
                Console.WriteLine("No se encontro ningun shipper con el ID: {0} \n", select);
            }
        }
        public void WriteConfirmDelete(Shippers ship)
        {
            Console.Clear();
            Console.Title = "Confirmar borrado";
            Console.WriteLine("Este es el elemento que esta intentando borrar");
            WriteInfoShipperUnit(ship);
            Console.WriteLine("¿Confimar borrado? \n");
            Console.WriteLine("1- Si \n");
            Console.WriteLine("2- No \n");
            if (MenuPrincipal.SelectOption() == 1)
            {
                Repository<Shippers> repository = new Repository<Shippers>();
                repository.Delete(ship.ShipperID);
                Console.WriteLine("");
                Console.WriteLine("Borrado realizado con exito \n");
            }
        }
        public static string WriteInsert(string tipe)
        {
            Console.Write("{0}:", tipe);
            string value = Console.ReadLine();
            return value;
        }
    }
}
