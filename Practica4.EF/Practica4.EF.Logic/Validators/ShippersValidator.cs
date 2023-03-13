using Practica4.EF.Entities.EntitiesDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.EF.Logic.Validators
{
    public class ShippersValidator
    {
        public Shippers ShipperExist(List<Shippers> ship, int select) 
        {
            Shippers searchShipper = ship.Find(s => s.ShipperID == select);
            if (searchShipper != null)
            {
                return searchShipper;
            }
            else
            {
                return null;
            }
        }
    }
}
