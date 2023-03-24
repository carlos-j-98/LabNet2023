using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica6.MVC.ServicesMVC.ExtensionMethods
{
    public static class ShipperExtension
    {
        public static List<ShippersView> ShipperListExtension(this List<Shippers> shippers)
        {
            return shippers.Select(s => new ShippersView
            {
                ID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();
        }
        public static ShipperViewDTO ShippersViewDTOExtension(this ShippersView shippersView)
        {
            return new ShipperViewDTO()
            {
                ID = shippersView.ID,
                CompanyName = shippersView.CompanyName,
                Phone = shippersView.Phone
            };
        }
        public static Shippers ToShippers(this ShippersView shippersView)
        {
            return new Shippers()
            {
                ShipperID = shippersView.ID,
                CompanyName = shippersView.CompanyName,
                Phone = shippersView.Phone
            };
        }
        public static ShippersView ToShippersView(this Shippers shippers)
        {
            return new ShippersView()
            {
                ID = shippers.ShipperID,
                CompanyName = shippers.CompanyName,
                Phone = shippers.Phone
            };
        }
    }
}