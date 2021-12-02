using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Cliente.Controllers
{
    [Authorize]

    public class InformeController : Controller
    {
        // GET: Informe
        public ActionResult Index()
        {
            ViewBag.info = new Informe().ReadAll();
            return View();
        }
    }
}