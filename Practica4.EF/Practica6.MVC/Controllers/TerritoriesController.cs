using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.LogicBussines;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class TerritoriesController : Controller
    {
        TerritorieLogic logic = new TerritorieLogic();
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
                Text = s.Description
            });
            territoriesOptions = new List<SelectListItem>
            {
                new SelectListItem {Value ="-1",Text="Nuevo"}
            }.Concat(territoriesOptions);
            ViewBag.shipOptions = new SelectList(territoriesOptions, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Modify(TerritoriesView territoriesView, string action)
        {
            try
            {
                if (action == "Agregar")
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
                else if (action == "Borrar")
                {
                    logic.Delete(territoriesView.ID);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
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