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
    public class ShippersController : Controller
    {
        private readonly ShipperViewDTOValidator shippersViewDTOValidator = new ShipperViewDTOValidator();
        private readonly ShipperLogic _logic = new ShipperLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            var shippers = _logic.GetAll();
            List<ShippersView> shippersView = shippers.Select(s => new ShippersView
            {
                ID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();
            return View(shippersView);
        }
        public ActionResult Modify()
        {
            var items = _logic.GetAll();
            List<ShippersView> shippersViewList = items.Select(s => new ShippersView
            {
                ID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();
            var shipOptions = shippersViewList.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.CompanyName + " - " + s.ID.ToString()
            });
            shipOptions = new List<SelectListItem>
            {
                new SelectListItem {Value ="-1",Text="Nuevo"}
            }.Concat(shipOptions);
            ViewBag.shipOptions = new SelectList(shipOptions, "Value", "Text");
            return View();
        }
        [Route("/Shippers/Modify/{request}")]
        [HttpPost]
        public ActionResult Modify(ShippersView shippersView, string request)
        {
            var shipDto = new Practica4.EF.Entities.DTO.ShipperViewDTO()
            {
                ID = shippersView.ID,
                CompanyName = shippersView.CompanyName,
                Phone = shippersView.Phone
            };
            var validatioResult = shippersViewDTOValidator.Validate(shipDto);
            if (!validatioResult.IsValid)
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
                        Shippers shipperEntity = new Shippers()
                        {
                            ShipperID = shippersView.ID,
                            CompanyName = shippersView.CompanyName,
                            Phone = shippersView.Phone
                        };
                        _logic.Update(shipperEntity);
                        return RedirectToAction("Index");
                    }
                    else if (request == "Borrar")
                    {
                        _logic.Delete(shippersView.ID);
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
        public ActionResult Delete(int id)
        {
            _logic.Delete(id);
            return View();
        }
        [HttpGet]
        public ActionResult GetByID(int id)
        {
            var shippers = _logic.GetById(id);
            var shippersView = new ShippersView()
            {
                ID = shippers.ShipperID,
                CompanyName = shippers.CompanyName,
                Phone = shippers.Phone
            };
            return new JsonResult() { Data = shippersView, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public ActionResult GetLastId()
        {
            return new JsonResult() { Data = _logic.GetNextId(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}