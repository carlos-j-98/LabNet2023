﻿using Microsoft.Ajax.Utilities;
using Practica4.EF.Entities.EntitiesDatabase;
using Practica4.EF.Logic.LogicBussines;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Practica4.EF.Services.Validators;
using Newtonsoft.Json;

namespace Practica6.MVC.Controllers
{
    public class ShippersController : Controller
    {
        private readonly ShipperViewDTOValidator shippersViewDTOValidator = new ShipperViewDTOValidator();
        ShipperLogic logic = new ShipperLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            var shippers = logic.GetAll();
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
            var items = logic.GetAll();
            List<ShippersView> shippersViewList = items.Select(s => new ShippersView
            {
                ID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();
            var shipOptions = shippersViewList.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.CompanyName
            });
            shipOptions = new List<SelectListItem>
            {
                new SelectListItem {Value ="-1",Text="Nuevo"}
            }.Concat(shipOptions);
            ViewBag.shipOptions = new SelectList(shipOptions, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Modify(ShippersView shippersView, string action)
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
                return RedirectToAction("Index","Error",new {error = erroresJson});
            }
            else
            {
                try
                {
                    if (action == "Agregar")
                    {
                        Shippers shipperEntity = new Shippers()
                        {
                            ShipperID = shippersView.ID,
                            CompanyName = shippersView.CompanyName,
                            Phone = shippersView.Phone
                        };
                        logic.Update(shipperEntity);
                        return RedirectToAction("Index");
                    }
                    else if (action == "Borrar")
                    {
                        logic.Delete(shippersView.ID);
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Error");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            logic.Delete(id);
            return View();
        }
        [HttpGet]
        public ActionResult GetByID(int id)
        {
            var shippers = logic.GetById(id);
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
            return new JsonResult() { Data = logic.GetNextId(),JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}