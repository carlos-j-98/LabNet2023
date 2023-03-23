using System.Collections.Generic;

namespace Practica4.EF.Data.Queries.InterfaceQueries
{
    public interface IGenericQuerie
    {
        List<T> GetAll<T>() where T : class;
        T GetById<T>(string id) where T : class;
        T GetById<T>(int id) where T : class;
        int GetNextIdShippers();
        string GetNextIdTerritories();
    }
}
