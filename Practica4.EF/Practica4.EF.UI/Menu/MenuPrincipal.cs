using Practica4.EF.Logic.ExtensionMethods;
using System;
using System.Configuration;
using System.Threading;

namespace Practica4.EF.UI.Menu
{
    public class MenuPrincipal
    {
        public MenuPrincipal()
        {

        }
        public void RunMenuPrincipal()
        {
            while (true)
            {
                WriteInitMenu();
                try
                {
                    switch (SelectOption())
                    {
                        case 1:
                            MenuConsultas.RunMenuConsultas();
                            break;
                        case 2:
                            MenuRepositorio.RunMenuRepositorio();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            WriteIncorrectOption();
                            break;
                    }
                    WriteBackMenu();
                }
                catch (FormatException ex)
                {
                    ex = new FormatException(ConfigurationManager.AppSettings["invalidFormatText"]);
                    WriteExceptionInfo(ex);
                    WriteBackMenu();
                }
                catch (InvalidOperationException ex) 
                {
                    ex = new InvalidOperationException();
                    WriteExceptionInfo(ex);
                    Console.WriteLine(ex.StackTrace);
                }
                catch (Exception ex)
                {
                    ex = new Exception(ConfigurationManager.AppSettings["exceptionGenericText"]);
                    WriteExceptionInfo(ex);
                    WriteBackMenu();
                }
            }
        }
        public void WriteInitMenu()
        {
            Console.Clear();
            Console.Title = "Menu principal ";
            Console.WriteLine("Menu principal de conexion a la base de datos \n");
            Console.WriteLine("¿Que desea hacer? \n");
            Console.WriteLine("1- Obtener datos de base de datos \n");
            Console.WriteLine("2- Cambiar datos de base de datos \n");
            Console.WriteLine("3- Salir \n");
        }
        public static void WriteBackMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Apreta un boton cualquiera para regresar al menu principal \n");
            Console.ReadKey();
        }
        public static void WriteExceptionInfo(Exception ex)
        {
            Console.WriteLine("");
            Console.WriteLine(ex.MessageExtension());
            Console.WriteLine(ex.TipeExtension());
        }
        public static void WriteIncorrectOption()
        {
            Console.WriteLine("");
            Console.WriteLine("Opcion incorrecta intente nuevamente \n");
            Thread.Sleep(2000);
        }
        public static int SelectOption()
        {
            int select = int.Parse(Console.ReadLine());
            return select;
        }
    }
}
