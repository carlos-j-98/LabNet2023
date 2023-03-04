using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;

namespace EjercicioPOOLab.Transporte.Entities.Models
{
    public class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {

        }
        public override string Avanzar()
        {
            return string.Format("Avanzando con {0} pasajeros, soy un taxi", GetPasajeros());
        }

        public override string Detenerse()
        {
            return string.Format("Me detuve con {0} pasajeros, soy un taxi", GetPasajeros());
        }
    }
}
