using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Profesional.Controllers
{
    [Authorize]

    public class HomeProfesionalController : Controller
    {
        // GET: HomeProfesional
        public ActionResult Index()
        {
            ViewData["sessionName"] = System.Web.HttpContext.Current.Session["sessionName"] as String;
            ViewBag.nombre = ViewData["sessionName"];
            return View();
        }

    }
}