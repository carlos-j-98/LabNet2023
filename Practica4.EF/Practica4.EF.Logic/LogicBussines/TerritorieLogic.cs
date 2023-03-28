using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Data.Repositorys;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Logic.LogicBussines
{
    public class TerritorieLogic : ITerritorieLogic
    {
        private readonly IGenericQuerie _territoriesQuerie;
        private readonly IRepository _repository;
        public TerritorieLogic(IGenericQuerie territoriesQueries, IRepository repository)
        {
            _territoriesQuerie = territoriesQueries;
            _repository = repository;
        }
        public void Add(Territories ship)
        {
            _repository.Add<Territories>(ship);
        }
        public void Delete(string id)
        {
            _repository.Delete<Territories>(id);
        }
        public void Update(Territories ship)
        {
            _repository.Update<Territories>(ship);
        }

        public List<Territories> GetAll()
        {
            return _territoriesQuerie.GetAll<Territories>();
        }
        public Territories GetById(string id)
        {
            return _territoriesQuerie.GetById<Territories>(id);
        }
        public string GetNextId()
        {
            return _territoriesQuerie.GetNextIdTerritories();
        }
    }
}
