using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Logic.LogicBussines
{
    public interface ITerritorieLogic
    {
        List<Territories> GetAll();
        Territories GetById(string id);
        void Add(Territories ship);
        void Delete(string id);
        void Update(Territories ship);
    }
}
