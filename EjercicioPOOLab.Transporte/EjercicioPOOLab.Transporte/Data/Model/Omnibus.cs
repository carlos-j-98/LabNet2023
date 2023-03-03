using EjercicioPOOLab.Transporte.Data.Abstract;

namespace EjercicioPOOLab.Transporte.Data.Model
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
