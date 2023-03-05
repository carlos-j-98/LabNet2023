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
            while (true)
            {
                WriteInit();
                try
                {
                    int select = int.Parse(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            menuActionTrans.WriteGoTrans(transList);
                            break;
                        case 2:
                            menuActionTrans.WriteStopTrans(transList);
                            break;
                        case 3:
                            transList = menuLoadTrans.RunMenuLoadTrans();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            WriteIncorrectOption();
                            break;
                    }
                }
                catch (FormatException)
                {
                    WriteInvalidFormat();
                    continue;
                }
                WriteBackToMenu();
            }
        }
        public void WriteInit()
        {
            Console.Clear();
            Console.Title = "Menu Principal";
            Console.WriteLine("¿Que desea hacer? \n");
            Console.WriteLine("1- Avanzar transportes \n");
            Console.WriteLine("2- Detener transportes \n");
            Console.WriteLine("3- Agregar Taxis y Omnibus \n");
            Console.WriteLine("4- Salir \n");
        }
        public void WriteBackToMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Presione cualquier boton para regresar al menu principal \n");
            Console.ReadKey();
        }
        public void WriteListNotHasTrans()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("La lista no contiene transportes publicos. Puede ingresarlos en el menu principal \n");
        }
        public static void WriteInvalidFormat()
        {
            Console.Clear();
            Console.WriteLine("Hubo un error, no se deben ingresar letras o simbolos, solo numeros. \n");
            Console.WriteLine("Volviendo al menu anterior \n");
            Thread.Sleep(2000);
        }
        public void WriteIncorrectOption()
        {
            Console.Clear();
            Console.WriteLine("Opcion incorrecta - Devolviendo al menu principal. \n");
            Thread.Sleep(3000);
        }
    }
}
