using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;

namespace EjercicioPOOLab.Transporte.Entities.Models
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros) : base(pasajeros)
        {

        }
        public override string Avanzar()
        {
            return string.Format("Avanzando con {0} pasajeros, soy un omnibus", GetPasajeros());
        }

        public override string Detenerse()
        {
            return string.Format("Me detuve con {0} pasajeros, soy un omnibus", GetPasajeros());
        }
    }
}
