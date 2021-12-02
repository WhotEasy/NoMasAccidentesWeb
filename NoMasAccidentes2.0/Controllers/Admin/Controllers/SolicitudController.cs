using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Admin.Controllers
{
    [Authorize]

    public class SolicitudController : Controller
    {
         
        // GET: Solicitud
        public ActionResult Index()
        {
            ViewBag.Solicitudes = new Solicitudes().ReadAll();
            return View();
        }
        private void EnviarProf()
        {
            ViewBag.profe = new Profes().ReadAll();
        }
        public ActionResult Edit(int id)
        {

            Registroactiv u = new Registroactiv().findsoli(id);
            if (u == null)
            {
                TempData["mensaje"] = "la solicitud no existe";
                return RedirectToAction("Index");
            }
            EnviarProf();
            return View(u);
        }

        //POST: registrov/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id_solicitud,rut_profesional")] Registroactiv registroactiv)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    EnviarProf();
                    return View(registroactiv);
                }
                registroactiv.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "No se ha modificado";
                return View(registroactiv);
            }
        }
    }
}