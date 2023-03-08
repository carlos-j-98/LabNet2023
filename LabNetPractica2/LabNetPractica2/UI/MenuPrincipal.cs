using LabNetPractica2.Application.ExtensionMethods;
using System;
using System.Configuration;
using System.Threading;

namespace LabNetPractica2.UI
{
    public class MenuPrincipal
    {
        public MenuPrincipal()
        {

        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    WriteInit();
                    int select = int.Parse(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            MenuOperations.WriteDivideByZero();
                            break;
                        case 2:
                            MenuOperations.WriteDivideNumbers();
                            break;
                        case 3:
                            MenuExceptions.WriteSelectException();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            WriteIncorrectOption();
                            continue;
                    }
                    WriteBackMenu();
                }
                catch (FormatException ex)
                {
                    ex = new FormatException(ConfigurationManager.AppSettings["invalidFormatText"]);
                    MenuPrincipal.WriteExceptionInfo(ex);
                    WriteBackMenu();
                }
                catch (Exception)
                {
                    new Exception("Ocurrio un error no controlado - regresando al menu principal \n");
                }
            }
        }
        public void WriteInit()
        {
            Console.Title = "Menu principal";
            Console.Clear();
            Console.WriteLine("Bienvenido al - MENU DE OPERACIONES - \n");
            Console.WriteLine("Cada opcion es distinta, leer atentamente \n");
            Console.WriteLine("1- Ingresar un NUMERADOR para ser dividido por {0} \n", ConfigurationManager.AppSettings["numStatic"]);
            Console.WriteLine("2- Ingresar un NUMERADOR y DENOMINADOR para dividirlos - Ojo si pones '0'\n");
            Console.WriteLine("3- Menu para mostrar excepciones \n");
            Console.WriteLine("4- Salir \n");
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
    }
}
