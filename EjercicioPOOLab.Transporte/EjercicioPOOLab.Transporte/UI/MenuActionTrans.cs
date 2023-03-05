using EjercicioPOOLab.Transporte.Application.Logic;
using EjercicioPOOLab.Transporte.Application.Validators;
using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using System;
using System.Collections.Generic;

namespace EjercicioPOOLab.Transporte.UI
{
    public class MenuActionTrans
    {
        public MenuPrincipal menuPrincipal;
        public MenuActionTrans()
        {
            menuPrincipal = new MenuPrincipal();
        }
        public void WriteTitleGoTrans()
        {
            Console.Clear();
            Console.Title = "Menu de avance de transportes";
            Console.WriteLine(" Los transportes publicos avanzan \n");
        }
        public void WriteTitleStopTrans()
        {
            Console.Clear();
            Console.Title = "Menu de detencion de transportes";
            Console.WriteLine(" Los transportes publicos se detienen \n");
        }
        public void WriteGoTrans(List<TransportePublico> transList)
        {
            if (TransportePublicoValidator.ListHasTrans(transList))
            {
                WriteTitleGoTrans();
                foreach (var item in transList)
                {
                    Console.WriteLine(GenericLogic.GoTrans(item));
                }
            }
            else
            {
                menuPrincipal.WriteListNotHasTrans();
            }
        }
        public void WriteStopTrans(List<TransportePublico> transList)
        {
            if (TransportePublicoValidator.ListHasTrans(transList)) 
            {
                WriteTitleStopTrans();
                foreach (var item in transList)
                {
                    Console.WriteLine(GenericLogic.StopTrans(item));
                }
            }
            else 
            {
                menuPrincipal.WriteListNotHasTrans();
            }
        }
    }
}
