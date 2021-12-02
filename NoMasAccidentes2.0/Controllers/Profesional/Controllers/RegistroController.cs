using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NomasAccidentes2._0;

namespace NoMasAccidentes2._0.Controllers.Profesional.Controllers
{
    [Authorize]

    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {

            ViewBag.reg = new Registroactiv().ReadAll();
            return View();
        
        }
        private void estadosol()
        {
            ViewBag.estadosol = new EstadoSol().ReadAll();
        }
        public ActionResult Edit(int id)
        {

            Solicitudes u = new Solicitudes().findsolis(id);
            if (u == null)
            {
                TempData["mensaje"] = "La solicitud no existe";
                return RedirectToAction("Index");
            }
            estadosol();

            return View(u);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID_SOLICITUD, FECHA_CIERRE, RESOLUCION, ID_ESTADO_SOLICITUDES")] Solicitudes solicitudes)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    estadosol();
                    return View(solicitudes);
                }
                solicitudes.Updates();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "No se ha modificado";
                return View(solicitudes);
            }
        }
        public ActionResult Delete(int id)
        {
            if (new Registroactiv().find(id) == null)
            {
                TempData["mensaje"] = "No existe el usuario";
                return RedirectToAction("Index");
            }
            if (new Registroactiv().Delete(id))
            {
                TempData["Mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "No se ha podido eliminar";
            return RedirectToAction("Index");
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}