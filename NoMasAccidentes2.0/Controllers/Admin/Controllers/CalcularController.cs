using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Admin.Controllers
{
    [Authorize]

    public class CalcularController : Controller
    {
        // GET: Calcular
        public ActionResult Index()
        {
            return View();
        }
    }
}