using Practica4.EF.Data.Queries;
using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Data.Repositorys;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Services.InterfaceService;
using System.Collections.Generic;

namespace Practica4.EF.Services
{
    public class TerritorieService : ITerritorieService
    {
        private readonly ITerritoriesQueries _territoriesQuerie;
        private readonly IRepository _repository;
        public TerritorieService()
        {
            _territoriesQuerie = new TerritorieQueries();
            _repository = new Repository();
        }
        public TerritorieService(ITerritoriesQueries territoriesQueries, IRepository repository)
        {
            _territoriesQuerie = territoriesQueries;
            _repository = repository;
        }
        public void Add(Territories ship)
        {
            _repository.Add<Territories>(ship);
        }
        public void Delete(int id)
        {
            _repository.Delete<Territories>(id);
        }
        public void Update(Territories ship)
        {
            _repository.Update<Territories>(ship);
        }

        public List<Territories> GetAll()
        {
            return _territoriesQuerie.GetAll();
        }
        public Territories GetById(string id)
        {
            return _territoriesQuerie.GetById(id);
        }
    }
}
