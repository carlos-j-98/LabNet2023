using LabNetPractica2.Application.CustomExceptions;
using LabNetPractica2.Application.Logic;
using System;

namespace LabNetPractica2.UI
{
    public class MenuExceptions
    {
        MenuExceptions()
        {

        }
        public static void WriteSelectException()
        {
            Console.Clear();
            Console.Title = "Menu disparar excepcion";
            Console.WriteLine("Bienvenido al menu que muestra una excepcion \n");
            Console.WriteLine("Seleccione que tipo de excepcion desea lanzar \n");
            Console.WriteLine("1- Excepcion 1 \n");
            Console.WriteLine("2- Excepcion custom \n");
            Console.WriteLine("3- Ninguna \n");
            Console.WriteLine("");
            try
            {
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Logic.LaunchException();
                        break;
                    case 2:
                        Logic.LaunchCustomException();
                        break;
                    case 3:
                        break;
                    default:
                        MenuPrincipal.WriteIncorrectOption();
                        WriteSelectException();
                        break;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MenuPrincipal.WriteExceptionInfo(ex);
            }
            catch (FormatException ex)
            {
                MenuPrincipal.WriteExceptionInfo(ex);
            }
            catch (CustomException ex)
            {
                MenuPrincipal.WriteExceptionInfo(ex);
            }
        }

    }
}
