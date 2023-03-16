﻿using PracticaLINQ.Services.ExtensionMethods;
using System;
using System.Configuration;
using System.Threading;

namespace PracticaLINQ.UI.Menu
{
    public class MenuPrincipal
    {
        private readonly CustomersPresentation _customersPresentation;
        private readonly ProductPresentation _productPresentation;
        public MenuPrincipal()
        {
            this._customersPresentation = new CustomersPresentation();
            this._productPresentation = new ProductPresentation();
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
                            _customersPresentation.WriteObjectCustomer();
                            break;
                        case 2:
                            _productPresentation.WriteListProducts("puntoDos");
                            break;
                        case 3:
                            _productPresentation.WriteListProducts("puntoTres");
                            break;
                        case 4:
                            _customersPresentation.WriteListCustomers("puntoCuatro");
                            break;
                        case 5:
                            _productPresentation.WriteProdutc("puntoCinco");
                            break;
                        case 6:
                            _customersPresentation.WriteListCustomersUpperLowerDTO();
                            break;
                        case 7:
                            _customersPresentation.WriteListCustomerOrdersDTO();
                            break;
                        case 8:
                            _customersPresentation.WriteListCustomers("puntoOcho");
                            break;
                        case 9:
                            _productPresentation.WriteListProducts("puntoNueve");
                            break;
                        case 10:
                            _productPresentation.WriteListProducts("puntoDiez");
                            break;
                        case 11:
                            _productPresentation.WriteProductCategoriesList();
                            break;
                        case 12:
                            _productPresentation.WriteProdutc("puntoDoce");
                            break;
                        case 13:
                            _customersPresentation.WriteCustCantOrderDTO();
                            break;
                        case 14:
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
                    WriteBackMenu();
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
            Console.WriteLine("--------------------------------- \n");
            Console.WriteLine("1-  Obtener un customer");
            Console.WriteLine("2-  Obtener productos sin stock");
            Console.WriteLine("3-  Obtener productos con stock y que valgan + de $3");
            Console.WriteLine("4-  Obtener customers de la region de WA");
            Console.WriteLine("5-  Obtener elemento o nulo de lista de productos donde el ID sea 789");
            Console.WriteLine("6-  Obtener nombre del customer en mayuscula y minuscula");
            Console.WriteLine("7-  Obtener customer y orders de WA y posteriores a 1/1/1997");
            Console.WriteLine("8-  Obtener 3 primeros customer de la region de WA");
            Console.WriteLine("9-  Obtener lista de productos ordenados por nombre");
            Console.WriteLine("10- Obtener lista de productos ordenados por 'unit in stock' de mayor a menor");
            Console.WriteLine("11- Obtener distintas categorias asociadas a productos");
            Console.WriteLine("12- Obtener primer elemento de una lista de productos");
            Console.WriteLine("13- Obtener customer con cantidad de ordenes asociadas");
            Console.WriteLine("14- Salir \n");
            Console.WriteLine("--------------------------------- \n");
            Console.Write("Eleccion: ");
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
