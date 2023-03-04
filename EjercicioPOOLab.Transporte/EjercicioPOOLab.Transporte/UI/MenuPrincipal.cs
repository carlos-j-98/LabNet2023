using EjercicioPOOLab.Transporte.Application.Validators;
using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EjercicioPOOLab.Transporte.UI
{
    public class MenuPrincipal
    {
        public List<TransportePublico> transList;
        public MenuActionTrans menuActionTrans;
        public MenuLoadTrans menuLoadTrans;
        public MenuPrincipal()
        {
            transList = new List<TransportePublico>();
        }
        public void Run()
        {
            menuActionTrans = new MenuActionTrans();
            menuLoadTrans = new MenuLoadTrans();
            menuLoadTrans.AddTrans(transList);
            while (true)
            {
                if (!TransportePublicoValidator.ListHasTrans(transList))
                {
                    menuLoadTrans.AddTrans(transList);
                }
                WriteInit();
                try
                {
                    int select = int.Parse(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            menuActionTrans.GoTrans(transList);
                            break;
                        case 2:
                            menuActionTrans.StopTrans(transList);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            IncorrectOption();
                            break;
                    }
                }
                catch (FormatException)
                {
                    WriteInvalidFormat();
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
        public void BackToMenu()
        {
            Console.WriteLine("\n Presione cualquier boton para volver al menu principal \n");
            Console.ReadKey();
        }
        public void ListNotHasTrans()
        {
            Console.Clear();
            Console.WriteLine("\n La lista no contiene transportes publicos. Redireccionando al menu de carga \n");
            Thread.Sleep(3000);
            menuLoadTrans.AddTrans(transList);
        }
        public void WriteInvalidFormat()
        {
            Console.Clear();
            Console.WriteLine("\n Hubo un error, no se deben ingresar letras o simbolos, solo numeros.");
            Console.WriteLine("\n Volviendo al menu anterior");
            Thread.Sleep(2000);
        }
        public void IncorrectOption()
        {
            Console.Clear();
            Console.WriteLine("Opcion incorrecta - Devolviendo al menu principal");
            Thread.Sleep(3000);
        }
    }
}
