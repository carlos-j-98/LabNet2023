using EjercicioPOOLab.Transporte.Application.Logic;
using EjercicioPOOLab.Transporte.Application.Validators;
using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace EjercicioPOOLab.Transporte.UI
{
    public class MenuLoadTrans
    {
        public List<TransportePublico> transList;
        public MenuPrincipal menuPrincipal;
        public int maxPlace;
        public int minPlace;
        public MenuLoadTrans()
        {
            menuPrincipal = new MenuPrincipal();
            maxPlace = int.Parse(ConfigurationManager.AppSettings["maxOmnibusPassanger"]);
            minPlace = int.Parse(ConfigurationManager.AppSettings["minCountPassanger"]);
            transList = new List<TransportePublico>();
        }
        public List<TransportePublico> RunMenuLoadTrans()
        {
            if (TransportePublicoValidator.ListHasTrans(transList))
            {
                WriteConfirmNewLoad();
                try
                {
                    int select = int.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        transList.Clear();
                        WriteAddTrans();
                    }
                    WriteSave();
                    return transList;

                }
                catch (Exception)
                {
                    MenuPrincipal.WriteInvalidFormat();
                    return transList;
                }
            }
            else
            {
                WriteAddTrans();
                return transList;
            }
        }
        public void WriteAddTrans()
        {
            while (transList.Count < int.Parse(ConfigurationManager.AppSettings["maxTransList"]))
            {
                GenericLogic.Settings(GenericLogic.TipeTransport(transList.Count), "tipeTransLoad");
                string tipeTransLoad = ConfigurationManager.AppSettings["tipeTransLoad"];
                maxPlace = GenericLogic.SetMaxPlace(tipeTransLoad);
                Console.Clear();
                Console.Title = "Agregar transportes";
                Console.WriteLine(" Bienvenido al menu para agregar transportes \n");
                Console.WriteLine(" Debera ingresar pasajeros para {1} faltantes {0}. \n", GenericLogic.MissingNumTrans(tipeTransLoad, transList), tipeTransLoad);
                Console.WriteLine(" La plaza maxima de {0} son {1} pasajeros con un minimo de {2} pasajeros \n", tipeTransLoad, maxPlace, minPlace);
                Console.WriteLine(" Ingrese la cantidad de pasajeros: \n");
                Console.WriteLine("");
                try
                {
                    int numPassanger = int.Parse(Console.ReadLine());
                    if (!TransportePublicoValidator.CanAddTrans(numPassanger, tipeTransLoad))
                    {
                        WriteIncorrectNumPassanger();
                        continue;
                    }
                    if (GenericLogic.TipeTransport(transList.Count) == ConfigurationManager.AppSettings["omnibus"])
                    {
                        transList.Add(OmnibusLogic.AddTrans(numPassanger));
                    }
                    else
                    {
                        transList.Add(TaxiLogic.AddTrans(numPassanger));
                    }
                }
                catch (FormatException)
                {
                    MenuPrincipal.WriteInvalidFormat();
                    continue;
                }
            }
        }
        public void WriteIncorrectNumPassanger()
        {
            Console.Clear();
            Console.WriteLine("Debe respetar la cantidad maxima y minima de pasajeros permitida, porfavor intente nuevamente. \n");
            Thread.Sleep(3000);
        }
        public void WriteConfirmNewLoad()
        {
            Console.Clear();
            Console.Title = "Nueva carga de transportes";
            Console.WriteLine("Actualmente la lista contiene una carga de transportes \n");
            Console.WriteLine("Si continua se eliminara la lista anterior y se creara una nueva con datos distintos \n");
            Console.WriteLine("¿ Desea CONTINUAR con la carga o desea CONSERVAR la lista actual? \n");
            Console.WriteLine("1- Continuar \n");
            Console.WriteLine("2- Conservar \n");
        }
        public void WriteSave()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Lista guardada \n");
        }
    }
}
