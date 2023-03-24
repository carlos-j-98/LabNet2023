using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica6.MVC.ServicesMVC.ExtensionMethods
{
    public static class SelectListExtension
    {
        public static IEnumerable<SelectListItem> ToSelectList(this List<TerritoriesView> territoriesViews)
        {
            return territoriesViews.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Description + " - " + s.ID.ToString()
            });
        }
        public static IEnumerable<SelectListItem> ToSelectList(this List<ShippersView> territoriesViews)
        {
            return territoriesViews.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.CompanyName + " - " + s.ID.ToString()
            });
        }
    }
}