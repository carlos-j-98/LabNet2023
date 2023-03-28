using Practica4.EF.Logic.LogicBussines;
using Practica4.EF.Services.ExtensionMethods;
using Practica4.EF.Services.Validators;
using Practica6.MVC.ServicesMVC.ExtensionMethods;
using Practica7.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
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
                    return BadRequest("No se encontraron shippers");
                }
                return Ok(shipList.ShipperListExtension());
            }
            catch
            {
                return NotFound();
            }
        }
        //Get api/Shipper/{id}
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var ship = _shipperLogic.GetById(id);
                if (ship == null)
                {
                    return BadRequest($"No se encontro el shipper de ID {id}");
                }
                return Ok(ship.ToShippersView());
            }
            catch
            {
                return InternalServerError();
            }
        }
        //Post api/Shipper/
        public IHttpActionResult CreateShip(ShippersView shipperView)
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
                _shipperLogic.Add(shipperView.ToShippers());
                return Ok(shipperView);
            }
            catch
            {
                return NotFound();
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
                return InternalServerError();
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
                    return BadRequest("El id es  necesario");
                }
                _shipperLogic.Delete(id);
                return Ok("El elemento fue eliminado");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}