using EjercicioPOOLab.Transporte.Data.Abstract;
using EjercicioPOOLab.Transporte.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EjercicioPOOLab.Transporte.Application
{
    public class Menu
    {
        public List<TransportePublico> transList;
        public Menu()
        {
            transList = new List<TransportePublico>();
        }
        public void Run()
        {
            AddTrans();
            while (true)
            {
                if (!ListHasTrans())
                {
                    AddTrans();
                }
                WriteInit();
                try
                {
                    int select = int.Parse(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            GoTrans();
                            break;
                        case 2:
                            StopTrans();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opcion incorrecta - Devolviendo al menu principal");
                            Thread.Sleep(3000);
                            break;
                    }
                }
                catch (FormatException)
                {
                    InvalidFormat();
                    continue;
                }
                BackToMenu();
            }
        }
        public void WriteInit()
        {
            Console.Clear();
            Console.Title = "Menu Principal";
            Console.WriteLine("¿Que desea hacer? \n");
            Console.WriteLine("1- Avanzar transportes");
            Console.WriteLine("2- Detener transportes");
            Console.WriteLine("3- Salir");
        }
        public void GoTrans()
        {
            Console.Clear();
            Console.Title = "Menu de avance de transportes";
            Console.WriteLine("Los transportes publicos avanzan \n");
            if (!ListHasTrans())
            {
                ListNotHasTrans();
            }
            else
            {
                foreach (var item in transList)
                {
                    Console.WriteLine(item.Avanzar());
                }
            }
        }
        public void StopTrans()
        {
            Console.Clear();
            Console.Title = "Menu de detencion de transportes";
            Console.WriteLine("Los transportes publicos se detienen\n");
            if (!ListHasTrans())
            {
                ListNotHasTrans();
            }
            else
            {
                foreach (var item in transList)
                {
                    Console.WriteLine(item.Detenerse());
                }
            }
        }
        public void BackToMenu()
        {
            Console.WriteLine("\n Presione cualquier boton para volver al menu principal \n");
            Console.ReadKey();
        }
        public bool ListHasTrans()
        {
            if (transList.Count != 0)
            {
                return true;
            }
            return false;
        }
        public void ListNotHasTrans()
        {
            Console.Clear();
            Console.WriteLine("\n La lista no contiene transportes publicos. Redireccionando al menu de carga \n");
            Thread.Sleep(3000);
            AddTrans();
        }
        public void AddTrans()
        {
            string tipeTransport = "Omnibus";
            while (transList.Count < 10)
            {
                WriteAddTrans(tipeTransport);
                try
                {
                    int numPassangers = int.Parse(Console.ReadLine());
                    if (!CanAddTrans(numPassangers, tipeTransport))
                    {
                        Console.WriteLine("\n Debe respetar la cantidad maxima y minima de pasajeros permitida, porfavor intente nuevamente.");
                        Thread.Sleep(3000);
                        continue;
                    }
                    LoadToList(numPassangers, tipeTransport);
                    if (transList.Count >= 5)
                    {
                        tipeTransport = "Taxi";
                    }
                }
                catch (FormatException)
                {
                    InvalidFormat();
                    continue;
                }
            }
        }

        public void WriteAddTrans(string tipeTransport)
        {
            int maxPlace = 100;
            int minPlace = 0;
            Console.Clear();
            Console.Title = "Agregar transportes";
            Console.WriteLine("\n Bienvenido al menu para agregar transportes \n");
            Console.WriteLine("\n Debera ingresar pasajeros para {0} {1}. \n", MissingNumPassangers(tipeTransport), tipeTransport);
            if (tipeTransport == "Taxi")
            {
                maxPlace = 4;
            }
            Console.WriteLine("\n La plaza maxima de {0} son {1} pasajeros con un minimo de {2} pasajeros \n", tipeTransport, maxPlace, minPlace);
            Console.WriteLine("\n Ingrese la cantidad de pasajeros: \n");
            Console.WriteLine("");
        }

        public int MissingNumPassangers(string tipeTransport)
        {
            if (tipeTransport == "Omnibus")
            {
                return 5 - transList.Count;
            }
            return 10 - transList.Count;
        }

        public bool CanAddTrans(int numPassangers, string TipeTransport)
        {
            if (TipeTransport == "Omnibus" && numPassangers >= 0 && numPassangers <= 100)
            {
                return true;
            }
            else if (TipeTransport == "Taxi" && numPassangers >= 0 && numPassangers <= 4)
            {
                return true;
            }
            return false;
        }

        public void LoadToList(int numPassangers, string TipeTransport)
        {
            if (TipeTransport == "Omnibus")
            {
                transList.Add(new Omnibus(numPassangers));
                return;
            }
            transList.Add(new Taxi(numPassangers));
        }
        public void InvalidFormat()
        {
            Console.Clear();
            Console.WriteLine("\n Hubo un error, no se deben ingresar letras o simbolos, solo numeros.");
            Console.WriteLine("\n Volviendo al menu anterior");
            Thread.Sleep(2000);
        }
    }
}
