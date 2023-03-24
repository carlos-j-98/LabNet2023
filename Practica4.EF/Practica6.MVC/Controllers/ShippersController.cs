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
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class ShippersController : Controller
    {
        private readonly ShipperViewDTOValidator shippersViewDTOValidator = new ShipperViewDTOValidator();
        private readonly ShipperLogic _logic = new ShipperLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            var shippers = _logic.GetAll();
            List<ShippersView> shippersView = shippers.ShipperListExtension();
            return View(shippersView);
        }
        public ActionResult Modify()
        {
            var items = _logic.GetAll();
            List<ShippersView> shippersViewList = items.ShipperListExtension();
            var shipOptions = shippersViewList.ToSelectList();
            shipOptions = new List<SelectListItem>
            {
                new SelectListItem {Value ="-1",Text="Nuevo"}
            }.Concat(shipOptions);
            ViewBag.shipOptions = new SelectList(shipOptions, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Modify(ShippersView shippersView, string request)
        {
            try
            {
                var shipDto = shippersView.ShippersViewDTOExtension();
                var validatioResult = shippersViewDTOValidator.Validate(shipDto);
                if (!validatioResult.IsValid)
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
                        Shippers shipperEntity = shippersView.ToShippers();
                        _logic.Update(shipperEntity);
                        return RedirectToAction("Index");
                    }
                    else if (request == "Borrar")
                    {
                        _logic.Delete(shippersView.ID);
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index", "Error", new { error = ConfigurationManager.AppSettings["invalidActionText"].ToJSON() });
                }
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Error", new { error = ConfigurationManager.AppSettings["argumentNullText"].ToJSON()});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new {error = ConfigurationManager.AppSettings["exceptionGenericText"].ToJSON() });
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _logic.Delete(id);
                return View();
            }
            catch (DbUpdateException)
            {
                return HttpNotFound($"No se pudo eliminar el elemento de ID {id}");
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult GetByID(int id)
        {

            try
            {
                var shippers = _logic.GetById(id);
                var shippersView = shippers.ToShippersView();
                return new JsonResult() { Data = shippersView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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