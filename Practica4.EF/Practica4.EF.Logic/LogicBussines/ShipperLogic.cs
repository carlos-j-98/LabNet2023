using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Data.Repositorys;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Logic.LogicBussines
{
    public class ShipperLogic : IShipperLogic
    {
        private readonly IRepository _repository;
        private readonly IGenericQuerie _shipperQuerie;
        public ShipperLogic(IRepository repository, IGenericQuerie genericQuerie)
        {
            this._shipperQuerie = genericQuerie;
            this._repository = repository;
        }
        public void Add(Shippers ship)
        {
            _repository.Add<Shippers>(ship);
        }
        public void Delete(int id)
        {
            _repository.Delete<Shippers>(id);
        }
        public void Update(Shippers ship)
        {
            _repository.Update<Shippers>(ship);
        }

        public List<Shippers> GetAll()
        {
            return _shipperQuerie.GetAll<Shippers>();
        }
        public Shippers GetById(int id)
        {
            return _shipperQuerie.GetById<Shippers>(id);
        }
        public int GetNextId()
        {
            return _shipperQuerie.GetNextIdShippers();
        }

        public Shippers GetLastElement()
        {
            return _shipperQuerie.GetLastElement<Shippers>();
        }
    }
}
