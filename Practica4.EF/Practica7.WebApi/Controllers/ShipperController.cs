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
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Practica7.WebApi.Controllers
{
    public class ShipperController : ApiController
    {
        private readonly IShipperLogic _shipperLogic;
        private readonly ShipperViewDTOValidator _validator = new ShipperViewDTOValidator();
        public ShipperController(IShipperLogic shipperLogic)
        {
            this._shipperLogic = shipperLogic;
        }
        //Get api/Shipper/
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var shipList = _shipperLogic.GetAll();
                if (shipList == null)
                {
                    throw new Exception();
                }
                return Ok(shipList.ShipperListExtension());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, new { mensaje = "No se encontraron Shippers." });
            }
        }
        //Get api/Shipper/{id}
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var ship = _shipperLogic.GetById(id);
                if (id == null)
                {
                    return Content(HttpStatusCode.BadRequest, new { mensaje = "El id es requerido." });
                }
                if(ship == null)
                {
                    throw new Exception();
                }
                return Ok(ship.ToShippersView());
            }
            catch(Exception)
            {
                return Content(HttpStatusCode.NotFound, new { mensaje = "No se encontraron Shippers con ese ID." });
            }
        }
        //Post api/Shipper/
        public IHttpActionResult CreateShip(ShippersView shipperView)
        {
            try
            {
                if (shipperView.ID == null || shipperView.ID == 0)
                {
                    shipperView.ID = _shipperLogic.GetNextId();
                }
                var terriDto = shipperView.ShippersViewDTOExtension();
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
                _shipperLogic.Add(shipperView.ToShippers());
                return Content(System.Net.HttpStatusCode.Created, _shipperLogic.GetLastElement().ToShippersView());
            }
            catch(Exception)
            {
                return Content(HttpStatusCode.BadRequest, new { mensaje = "Los datos enviados son inválidos." });
            }
        }
        //Put api/Shipper/{id}
        [HttpPut]
        public IHttpActionResult UpdateShipper([FromBody] ShippersView shipperView)
        {
            try
            {
                if (shipperView.ID == null)
                {
                    shipperView.ID = _shipperLogic.GetNextId();
                }
                var terriDto = shipperView.ShippersViewDTOExtension();
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
                _shipperLogic.Update(shipperView.ToShippers());
                return Content(System.Net.HttpStatusCode.Created, shipperView);
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, new { mensaje = "Los datos enviados son inválidos." });
            }
        }
        //Delete api/Shipper/{id}
        [HttpDelete]
        public IHttpActionResult DeleteShipper(int id)
        {
            try
            {
                if (id == null)
                {
                    return Content(HttpStatusCode.BadRequest, new { mensaje = "El id es requerido." });
                }
                if(_shipperLogic.GetById(id) != null)
                {
                    _shipperLogic.Delete(id);
                    return Content(HttpStatusCode.OK, new {mensaje = "El elemento fue eliminado" });
                }
                throw new Exception();
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.NotFound, new { mensaje = "El id no fue encontrado." });
            }
        }
    }
}