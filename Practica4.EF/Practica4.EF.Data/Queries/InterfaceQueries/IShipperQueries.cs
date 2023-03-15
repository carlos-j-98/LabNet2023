using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Data.Queries.InterfaceQueries
{
    public interface IShipperQueries
    {
        List<Shippers> GetAll();
        Shippers GetById(int id);
    }
}
