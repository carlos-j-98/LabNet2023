using Practica4.EF.Logic.LogicBussines;
using Practica4.EF.Services.ExtensionMethods;
using Practica4.EF.Services.Validators;
using Practica6.MVC.ServicesMVC.ExtensionMethods;
using Practica7.WebApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;

namespace Practica7.WebApi.Controllers
{
    public class TerritorieController : ApiController
    {
        private TerritorieLogic _territorieLogic = new TerritorieLogic();
        private TerritoriesViewDTOValidator _validator = new TerritoriesViewDTOValidator();
        //Get api/Territorie/
        public IHttpActionResult GetAll()
        {
            try
            {
                var terriList = _territorieLogic.GetAll();
                if (terriList == null) 
                {
                    return BadRequest("No se encontraron territorios");
                }
                return Ok(terriList.TerritoriesListExtension());
            }
            catch
            {
                return InternalServerError();
            }
        }
        //Get api/Territorie/{id}
        public IHttpActionResult GetById(string id)
        {
            try
            {
                var terri = _territorieLogic.GetById(id);
                if (terri == null)
                {
                    return BadRequest($"No se encontro el territorio de ID {id}");
                }
                return Ok(terri.ToTerritoriesView());
            }
            catch
            {
                return InternalServerError();
            }
        }
        //Post api/Territorie/
        public IHttpActionResult CreateTerritorie(TerritoriesView territoriesView)
        {
            try
            {
                if(territoriesView.ID == null)
                {
                    territoriesView.ID = _territorieLogic.GetNextId();
                }
                var terriDto = territoriesView.TerritoriesViewDTOExtension();
                var validationResult = _validator.Validate(terriDto);
                if (!validationResult.IsValid)
                {
                    List<object> errores = new List<object>();
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        errores.Add(error.ErrorMessage);
                    }
                    return BadRequest(errores.ToJSONList());
                }
                _territorieLogic.Add(territoriesView.ToTerritories());
                return Ok(territoriesView);
            }
            catch
            {
                return InternalServerError();
            }
        }
        //Put api/Territorie/{id}
        [HttpPut]
        public IHttpActionResult UpdateTerritorie([FromBody]TerritoriesView territoriesView)
        {
            try
            {
                if (territoriesView.ID == null)
                {
                    territoriesView.ID = _territorieLogic.GetNextId();
                }
                var terriDto = territoriesView.TerritoriesViewDTOExtension();
                var validationResult = _validator.Validate(terriDto);
                if (!validationResult.IsValid)
                {
                    List<object> errores = new List<object>();
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        errores.Add(error.ErrorMessage);
                    }
                    return BadRequest(errores.ToJSONList());
                }
                _territorieLogic.Update(territoriesView.ToTerritories());
                return Ok(territoriesView);
            }
            catch
            {
                return InternalServerError();
            }
        }
        //Delete api/Territorie/{id}
        [HttpDelete]
        public IHttpActionResult UpdateTerritorie(string id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("El id es  necesario");
                }
                _territorieLogic.Delete(id);
                return Ok("El elemento fue eliminado");
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}