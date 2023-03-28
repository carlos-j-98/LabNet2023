using Practica4.EF.Logic.LogicBussines;
using Practica4.EF.Services.ExtensionMethods;
using Practica4.EF.Services.Validators;
using Practica6.MVC.ServicesMVC.ExtensionMethods;
using Practica7.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
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
                    return BadRequest("No se encontraron territorios");
                }
                return Ok(terriList.TerritoriesListExtension());
            }
            catch
            {
                return NotFound();
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
                    return BadRequest("El id es requerido");
                }
                return Ok(terri.ToTerritoriesView());
            }
            catch
            {
                return NotFound();
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
                return Content(System.Net.HttpStatusCode.Created, territoriesView);
            }
            catch
            {
                return BadRequest("No se pudo crear");
            }
        }
        //Put api/Territorie/{id}
        [HttpPut]
        public IHttpActionResult UpdateTerritorie([FromBody] TerritoriesView territoriesView)
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
                return BadRequest("No se pudo actualizar");
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
                    return BadRequest("El id es requerido");
                }
                _territorieLogic.Delete(id);
                return Ok(new JsonResult()
                { Data = "El elemento fue eliminado", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
            catch
            {
                return NotFound();
            }
        }
    }
}