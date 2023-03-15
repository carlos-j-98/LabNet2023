using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Services.InterfaceService
{
    public interface IShipperService
    {
        List<Shippers> GetAll();
        Shippers GetById(int id);
        void Add(Shippers ship);
        void Delete(int id);
        void Update(Shippers ship);
    }
}
