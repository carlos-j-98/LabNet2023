using Newtonsoft.Json;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.LogicBussines;
using Practica4.EF.Services.Validators;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class TerritoriesController : Controller
    {
        private readonly TerritorieLogic logic = new TerritorieLogic();
        private readonly TerritoriesViewDTOValidator _validator = new TerritoriesViewDTOValidator();
        // GET: Territories
        public ActionResult Index()
        {
            var territories = logic.GetAll();
            List<TerritoriesView> terriList = territories.Select(t => new TerritoriesView
            {
                ID = t.TerritoryID,
                Description = t.TerritoryDescription,
                RegionID = t.RegionID
            }).ToList();
            return View(terriList);
        }
        public ActionResult Modify()
        {
            var items = logic.GetAll();
            List<TerritoriesView> territoriesViews = items.Select(t => new TerritoriesView
            {
                ID = t.TerritoryID,
                Description = t.TerritoryDescription,
                RegionID = t.RegionID
            }).ToList();
            var territoriesOptions = territoriesViews.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Description + " - " + s.ID.ToString()
            });
            territoriesOptions = new List<SelectListItem>
            {
                new SelectListItem {Value ="-1",Text="Nuevo"}
            }.Concat(territoriesOptions);
            ViewBag.shipOptions = new SelectList(territoriesOptions, "Value", "Text");
            return View();
        }
        [Route("/Territories/Modify/{request}")]
        [HttpPost]
        public ActionResult Modify(TerritoriesView territoriesView, string request)
        {
            var terriDto = new Practica4.EF.Entities.DTO.TerritoriesViewDTO()
            {
                ID = territoriesView.ID,
                Description = territoriesView.Description,
                RegionID = territoriesView.RegionID
            };
            var validationResult = _validator.Validate(terriDto);
            if (!validationResult.IsValid)
            {
                List<object> errores = new List<object>();
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    errores.Add(error.ErrorMessage);
                }
                string erroresJson = JsonConvert.SerializeObject(errores);
                return RedirectToAction("Index", "Error", new { error = erroresJson });
            }
            else
            {
                try
                {
                    if (request == "Agregar")
                    {
                        Territories territoriesEntity = new Territories()
                        {
                            TerritoryID = territoriesView.ID.ToString(),
                            TerritoryDescription = territoriesView.Description,
                            RegionID = territoriesView.RegionID
                        };
                        logic.Update(territoriesEntity);
                        return RedirectToAction("Index");
                    }
                    else if (request == "Borrar")
                    {
                        logic.Delete(territoriesView.ID);
                        return RedirectToAction("Index");
                    }
                    throw new Exception();
                }
                catch (ArgumentNullException)
                {
                    string exceptionError = "El elemento no se puede borrar debido a que esta siendo utilizado";
                    string json = JsonConvert.SerializeObject(new { error = exceptionError });
                    return RedirectToAction("Index", "Error", new { error = json });
                }
                catch (Exception ex)
                {
                    string exceptionError = "Ocurrio un error desconocido intente nuevamente";
                    string json = JsonConvert.SerializeObject(new { error = exceptionError, mensaje = ex.Message });
                    return RedirectToAction("Index", "Error", new { error = json });
                }
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            logic.Delete(id);
            return View();
        }
        [HttpGet]
        public ActionResult GetByID(string id)
        {
            var territories = logic.GetById(id);
            var territoriesView = new TerritoriesView()
            {
                ID = territories.TerritoryID,
                Description = territories.TerritoryDescription,
                RegionID = territories.RegionID
            };
            return new JsonResult() { Data = territoriesView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public ActionResult GetLastId()
        {
            return new JsonResult() { Data = logic.GetNextId(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}