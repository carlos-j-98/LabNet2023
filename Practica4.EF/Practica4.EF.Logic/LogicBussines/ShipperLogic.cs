using Practica4.EF.Data.Queries;
using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Data.Repositorys;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Logic.LogicBussines
{
    public class ShipperLogic : IShipperLogic
    {
        private readonly IRepository _repository;
        private readonly IShipperQueries _shipperQuerie;
        public ShipperLogic()
        {
            this._shipperQuerie = new ShipperQueries();
            this._repository = new Repository();
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
            return _shipperQuerie.GetAll();
        }
        public Shippers GetById(int id)
        {
            return _shipperQuerie.GetById(id);
        }


    }
}
