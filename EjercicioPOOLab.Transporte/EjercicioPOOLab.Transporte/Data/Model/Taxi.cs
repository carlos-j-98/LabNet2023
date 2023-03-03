using EjercicioPOOLab.Transporte.Data.Abstract;

namespace EjercicioPOOLab.Transporte.Data.Model
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
