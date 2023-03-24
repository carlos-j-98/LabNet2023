using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica6.MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Practica6.MVC.ServicesMVC.ExtensionMethods
{
    public static class TerritorieExtension
    {
        public static List<TerritoriesView> TerritoriesListExtension(this List<Territories> territories)
        {
            return territories.Select(t => new TerritoriesView
            {
                ID = t.TerritoryID,
                Description = t.TerritoryDescription,
                RegionID = t.RegionID
            }).ToList();
        }
        public static TerritoriesViewDTO TerritoriesViewDTOExtension(this TerritoriesView territoriesView)
        {
            return new TerritoriesViewDTO()
            {
                ID = territoriesView.ID,
                Description = territoriesView.Description,
                RegionID = territoriesView.RegionID
            };
        }
        public static Territories ToTerritories(this TerritoriesView territoriesView)
        {
            return new Territories()
            {
                TerritoryID = territoriesView.ID.ToString(),
                TerritoryDescription = territoriesView.Description,
                RegionID = territoriesView.RegionID
            };
        }
        public static TerritoriesView ToTerritoriesView(this Territories territories)
        {
            return new TerritoriesView()
            {
                ID = territories.TerritoryID,
                Description = territories.TerritoryDescription,
                RegionID = territories.RegionID
            };
        }
    }
}