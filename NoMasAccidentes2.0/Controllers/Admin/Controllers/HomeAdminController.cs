using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Admin.Controllers
{
    [Authorize]
    public class HomeAdminController : Controller
    {
      

        // GET: HomeAdmin
        public ActionResult Inicio()
        {
            ViewData["sessionName"] = System.Web.HttpContext.Current.Session["sessionName"] as String;
            ViewBag.nombre = ViewData["sessionName"];
            return View();
        }
    }
}