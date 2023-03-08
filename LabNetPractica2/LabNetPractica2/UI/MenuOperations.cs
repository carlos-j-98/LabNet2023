using LabNetPractica2.Application.ExtensionMethods;
using System;
using System.Configuration;

namespace LabNetPractica2.UI
{
    public class MenuOperations
    {
        public MenuOperations()
        {

        }
        public static void WriteDivideByZero()
        {
            Console.Clear();
            double numStatic = double.Parse(ConfigurationManager.AppSettings["numStatic"]);
            Console.Title = $"Menu de dividir por {numStatic}";
            Console.WriteLine("Bienvenido al menu para realizar divisiones por {0} \n", numStatic);
            Console.WriteLine("Ingresa un numero para que sea dividido por {0} \n", numStatic);
            try
            {
                WriteAddNumber("Numerador");
                double num = double.Parse(Console.ReadLine());
                if (numStatic.DoubleIsZero())
                {
                    throw new DivideByZeroException();
                }
                Console.WriteLine("");
                double result = num.Divide(numStatic);
                Console.WriteLine(result.WriteResult());
                Console.WriteLine("La operacion de division fue exitosa \n");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("La operacion no pudo realizarce \n");
                ex = new DivideByZeroException();
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                ex = new FormatException(ConfigurationManager.AppSettings["invalidFormatText"]);
                MenuPrincipal.WriteExceptionInfo(ex);
            }
        }
        public static void WriteDivideNumbers()
        {
            Console.Clear();
            Console.Title = "Menu de divisiones";
            Console.WriteLine("Bienvenido al menu para realizar divisiones \n");
            Console.WriteLine("Vas a ingresar un NUMERADOR y un DENOMINADOR en ese orden para realizar una division \n");
            try
            {
                WriteAddNumber("Numerador");
                double numerator = double.Parse(Console.ReadLine());
                WriteAddNumber("Denominador");
                double denominator = double.Parse(Console.ReadLine());
                Console.WriteLine("");
                double result = numerator.Divide(denominator);
                if (result == double.PositiveInfinity)
                {
                    throw new DivideByZeroException();
                }
                Console.WriteLine(result.WriteResult());
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("Veo mas factible que se pueda dividir por cero que tener una economia estable en Argentina y aun asi no se puede ninguna \n");
                ex = new DivideByZeroException();
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                ex = new FormatException(ConfigurationManager.AppSettings["invalidFormatText"]);
                MenuPrincipal.WriteExceptionInfo(ex);
            }
        }
        public static void WriteAddNumber(string value)
        {
            Console.WriteLine("");
            Console.Write("{0}: ", value);
        }
    }
}