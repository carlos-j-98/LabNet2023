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
        public void StopTrans(List<TransportePublico> transList)
        {
            WriteTitleStopTrans();
            if (!TransportePublicoValidator.ListHasTrans(transList))
            {
                menuPrincipal.WriteListNotHasTrans();
            }
            else
            {
                WriteStopTrans(transList);
            }
        }
        public void GoTrans(List<TransportePublico> transList)
        {
            WriteTitleGoTrans();
            if (!TransportePublicoValidator.ListHasTrans(transList))
            {
                menuPrincipal.WriteListNotHasTrans();
            }
            else
            {
                WriteGoTrans(transList);
            }
        }
        public void WriteTitleGoTrans()
        {
            Console.Clear();
            Console.Title = "Menu de avance de transportes";
            Console.WriteLine("Los transportes publicos avanzan \n");
        }
        public void WriteTitleStopTrans()
        {
            Console.Clear();
            Console.Title = "Menu de detencion de transportes";
            Console.WriteLine("Los transportes publicos se detienen\n");
        }
        public void WriteGoTrans(List<TransportePublico> transList) 
        {
            foreach (var item in transList)
            {
                Console.WriteLine(item.Avanzar());
            }
        }
        public void WriteStopTrans(List<TransportePublico> transList) 
        {
            foreach (var item in transList)
            {
                Console.WriteLine(item.Detenerse());
            }
        }
    }
}
