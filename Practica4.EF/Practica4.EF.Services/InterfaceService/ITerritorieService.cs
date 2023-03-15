using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Services.InterfaceService
{
    public interface ITerritorieService
    {
        List<Territories> GetAll();
        Territories GetById(string id);
        void Add(Territories ship);
        void Delete(int id);
        void Update(Territories ship);
    }
}
