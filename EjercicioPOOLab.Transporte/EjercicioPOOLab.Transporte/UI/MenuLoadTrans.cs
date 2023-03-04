using EjercicioPOOLab.Transporte.Application.Validators;
using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using EjercicioPOOLab.Transporte.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EjercicioPOOLab.Transporte.UI
{
    public class MenuLoadTrans
    {
        public MenuPrincipal menuPrincipal;
        public int maxPlace;
        public int minPlace;
        public MenuLoadTrans()
        {
            menuPrincipal = new MenuPrincipal();
            maxPlace = 100;
            minPlace = 0;
        }
        public void AddTrans(List<TransportePublico> transList)
        {
            string tipeTransport = "Omnibus";
            while (transList.Count < 10)
            {
                WriteAddTrans(tipeTransport, transList);
                try
                {
                    int numPassangers = int.Parse(Console.ReadLine());
                    if (!TransportePublicoValidator.CanAddTrans(numPassangers, tipeTransport))
                    {
                        WriteIncorrectNumPassanger();
                        continue;
                    }
                    LoadToList(numPassangers, tipeTransport, transList);
                    tipeTransport = TipeTransport(transList.Count);
                }
                catch (FormatException)
                {
                    menuPrincipal.WriteInvalidFormat();
                    continue;
                }
            }
        }
        public void WriteAddTrans(string tipeTransport, List<TransportePublico> transList)
        {
            SetMaxPlace(tipeTransport);
            Console.Clear();
            Console.Title = "Agregar transportes";
            Console.WriteLine("\n Bienvenido al menu para agregar transportes \n");
            Console.WriteLine("\n Debera ingresar pasajeros para {0} {1}. \n", MissingNumPassangers(tipeTransport, transList), tipeTransport);
            Console.WriteLine("\n La plaza maxima de {0} son {1} pasajeros con un minimo de {2} pasajeros \n", tipeTransport, maxPlace, minPlace);
            Console.WriteLine("\n Ingrese la cantidad de pasajeros: \n");
            Console.WriteLine("");
        }
        public int MissingNumPassangers(string tipeTransport, List<TransportePublico> transList)
        {
            if (tipeTransport == "Omnibus")
            {
                return 5 - transList.Count;
            }
            return 10 - transList.Count;
        }
        public void LoadToList(int numPassangers, string TipeTransport, List<TransportePublico> transList)
        {
            if (TipeTransport == "Omnibus")
            {
                transList.Add(new Omnibus(numPassangers));
                return;
            }
            transList.Add(new Taxi(numPassangers));
        }
        public string TipeTransport(int numPassangers)
        {
            if (numPassangers >= 5)
            {
                return "Taxi";
            }
            return "Omnibus";
        }
        public void SetMaxPlace(string tipeTransport)
        {
            if (tipeTransport == "Taxi")
            {
                maxPlace = 4;
            }
        }
        public void WriteIncorrectNumPassanger()
        {
            Console.WriteLine("\n Debe respetar la cantidad maxima y minima de pasajeros permitida, porfavor intente nuevamente.");
            Thread.Sleep(3000);
        }
    }
}
