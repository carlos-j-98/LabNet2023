using Microsoft.Practices.Unity;
using Practica4.EF.Data.Queries;
using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Data.Repositorys;
using Practica4.EF.Logic.LogicBussines;
using Practica4.EF.Logic.LogicBussines.LogicInterface;
using System.Web.Mvc;
using Unity.Mvc3;

namespace Practica6.MVC
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IShipperLogic, ShipperLogic>();
            container.RegisterType<ITerritorieLogic, TerritorieLogic>();
            container.RegisterType<IPokemonLogic, PokemonLogic>();

            container.RegisterType<IGenericQuerie, GenericQuery>();
            container.RegisterType<IPokemonQuerie, PokemonQuerie>();
            container.RegisterType<IRepository, Repository>();

            return container;
        }
    }
}