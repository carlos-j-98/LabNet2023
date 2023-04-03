using Microsoft.Practices.Unity;
using Practica4.EF.Data.Queries;
using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Data.Repositorys;
using Practica4.EF.Logic.LogicBussines;
using Practica7.WebApi.App_Start;
using System.Web.Http;

namespace Practica7.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IShipperLogic, ShipperLogic>();
            container.RegisterType<ITerritorieLogic, TerritorieLogic>();

            container.RegisterType<IGenericQuerie, GenericQuery>();
            container.RegisterType<IRepository, Repository>();
            config.DependencyResolver = new UnityResolver(container);
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
