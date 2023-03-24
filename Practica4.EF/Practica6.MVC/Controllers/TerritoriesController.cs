using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.LogicBussines;
using Practica4.EF.Services.ExtensionMethods;
using Practica4.EF.Services.Validators;
using Practica6.MVC.Models;
using Practica6.MVC.ServicesMVC.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class TerritoriesController : Controller
    {
        private readonly TerritorieLogic _logic = new TerritorieLogic();
        private readonly TerritoriesViewDTOValidator _validator = new TerritoriesViewDTOValidator();
        // GET: Territories
        public ActionResult Index()
        {
            var territories = _logic.GetAll();
            List<TerritoriesView> terriList = territories.TerritoriesListExtension();
            return View(terriList);
        }
        public ActionResult Modify()
        {
            var items = _logic.GetAll();
            List<TerritoriesView> territoriesViews = items.TerritoriesListExtension();
            var territoriesOptions = territoriesViews.ToSelectList();
            territoriesOptions = new List<SelectListItem>
            {
                new SelectListItem {Value ="-1",Text="Nuevo"}
            }.Concat(territoriesOptions);
            ViewBag.shipOptions = new SelectList(territoriesOptions, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Modify(TerritoriesView territoriesView, string request)
        {
            try
            {
                var terriDto = territoriesView.TerritoriesViewDTOExtension();
                var validationResult = _validator.Validate(terriDto);
                if (!validationResult.IsValid)
                {
                    List<object> errores = new List<object>();
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        errores.Add(error.ErrorMessage);
                    }
                    return RedirectToAction("Index", "Error", new {error = errores.ToJSONList() });
                }
                else
                {
                    if (request == "Agregar")
                    {
                        Territories territoriesEntity = territoriesView.ToTerritories();
                        _logic.Update(territoriesEntity);
                        return RedirectToAction("Index");
                    }
                    else if (request == "Borrar")
                    {
                        _logic.Delete(territoriesView.ID);
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index", "Error", new {error = ConfigurationManager.AppSettings["invalidActionText"].ToJSON() });
                }
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Error", new {error = ConfigurationManager.AppSettings["argumentNullText"].ToJSON() });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error", new { error = ConfigurationManager.AppSettings["exceptionGenericText"].ToJSON() });
            }

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                _logic.Delete(id);
                return View();
            }
            catch (NullReferenceException)
            {
                return HttpNotFound($"No se pudo eliminar el elemento de ID {id}");
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult GetByID(string id)
        {
            try
            {
                var territories = _logic.GetById(id);
                var territoriesView = territories.ToTerritoriesView();
                return new JsonResult() { Data = territoriesView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (NullReferenceException)
            {
                return HttpNotFound($"No se encontro el elemento de ID {id}");
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult GetLastId()
        {
            try
            {
                return new JsonResult() { Data = _logic.GetNextId(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (NullReferenceException)
            {

                return HttpNotFound("No se encontraron elementos que cumplan con lo requerido");
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }
    }
}