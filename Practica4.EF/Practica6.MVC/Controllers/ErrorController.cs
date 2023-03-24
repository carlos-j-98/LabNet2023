using Newtonsoft.Json;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                var erroresJson = JsonConvert.DeserializeObject(error);
                ViewBag.Errores = erroresJson;
            }
            return View();
        }
    }
}