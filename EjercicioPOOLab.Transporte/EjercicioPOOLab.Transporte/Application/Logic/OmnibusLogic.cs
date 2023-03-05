using EjercicioPOOLab.Transporte.Entities.Interfaces.Abstract;
using EjercicioPOOLab.Transporte.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOOLab.Transporte.Application.Logic
{
    public class OmnibusLogic
    {
        public static TransportePublico AddTrans(int numPassanger)
        {
            return new Omnibus(numPassanger);
        }
    }
}
