using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using EjercicioPOOLab.Transporte.Entities.Models;

namespace EjercicioPOOLab.Transporte.Application.Logic
{
    public class TaxiLogic
    {
        public static TransportePublico AddTrans(int numPassanger)
        {
            return new Taxi(numPassanger);
        }
    }
}
