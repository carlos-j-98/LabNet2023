using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using System.Collections.Generic;

namespace EjercicioPOOLab.Transporte.Application.Validators
{
    public class TransportePublicoValidator
    {
        public TransportePublicoValidator()
        {

        }
        public static bool ListHasTrans(List<TransportePublico> transList)
        {
            if (transList.Count != 0)
            {
                return true;
            }
            return false;
        }
        public static bool CanAddTrans(int numPassangers, string TipeTransport)
        {
            if (TipeTransport == "Omnibus" && numPassangers >= 0 && numPassangers <= 100)
            {
                return true;
            }
            else if (TipeTransport == "Taxi" && numPassangers >= 0 && numPassangers <= 4)
            {
                return true;
            }
            return false;
        }
    }
}
