using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Data.Queries.InterfaceQueries
{
    public interface ITerritoriesQueries
    {
        List<Territories> GetAll();
        Territories GetById(string id);
    }
}
