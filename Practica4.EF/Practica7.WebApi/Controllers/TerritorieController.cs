using Practica4.EF.Logic.LogicBussines;
using Practica4.EF.Services.ExtensionMethods;
using Practica4.EF.Services.Validators;
using Practica6.MVC.ServicesMVC.ExtensionMethods;
using Practica7.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Practica7.WebApi.Controllers
{
    public class TerritorieController : ApiController
    {
        private ITerritorieLogic _territorieLogic;
        private TerritoriesViewDTOValidator _validator = new TerritoriesViewDTOValidator();
        public TerritorieController(ITerritorieLogic territorieLogic)
        {
            _territorieLogic = territorieLogic;
        }
        //Get api/Territorie/
        public IHttpActionResult GetAll()
        {
            try
            {
                var terriList = _territorieLogic.GetAll();
                if (terriList == null)
                {
                    throw new Exception();
                }
                return Ok(terriList.TerritoriesListExtension());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, new { mensaje = "No se encontraron Territories." });
            }
        }
        //Get api/Territorie/{id}
        public IHttpActionResult GetById(string id)
        {
            try
            {
                if (id == null)
                {
                    return Content(HttpStatusCode.BadRequest, new { mensaje = "El id es requerido." });
                }
                var terri = _territorieLogic.GetById(id);
                if(terri == null)
                {
                    throw new Exception();
                }
                return Ok(terri.ToTerritoriesView());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, new { mensaje = "No se encontraron Territories con ese ID." });
            }
        }
        //Post api/Territorie/
        public IHttpActionResult CreateTerritorie(TerritoriesView territoriesView)
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
                _territorieLogic.Add(territoriesView.ToTerritories());
                return Content(System.Net.HttpStatusCode.Created, _territorieLogic.GetLastElement().ToTerritoriesView());
            }
            catch (NullReferenceException)
            {
                return Content(HttpStatusCode.BadRequest, new { mensaje = "Los datos enviados son inválidos." });
            }
        }
        //Put api/Territorie/{id}
        [HttpPut]
        public IHttpActionResult UpdateTerritorie([FromBody] TerritoriesView territoriesView)
        {
            try
            {
                if (territoriesView.ID == null || territoriesView.ID == "0")
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
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, new { mensaje = "Los datos enviados son inválidos." });
            }
        }
        //Delete api/Territorie/{id}
        [HttpDelete]
        public IHttpActionResult DeleteTerritorie(string id)
        {
            try
            {
                if (id == null)
                {
                    return Content(HttpStatusCode.BadRequest, new { mensaje = "El id es requerido." });
                }
                if(_territorieLogic.GetById(id) != null)
                {
                    _territorieLogic.Delete(id);
                    return Content(HttpStatusCode.OK, new {mensaje = "El elemento fue eliminado" });
                }
                throw new Exception();
            }
            catch(Exception)
            {
                return Content(HttpStatusCode.NotFound, new { mensaje = "El id no fue encontrado." });
            }
        }
    }
}