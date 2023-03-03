namespace EjercicioPOOLab.Transporte.Data.Abstract
{
    public abstract class TransportePublico
    {
        private int pasajeros;
        public TransportePublico(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }
        public abstract string Avanzar();
        public abstract string Detenerse();
        public int GetPasajeros() { return pasajeros; }
    }
}
