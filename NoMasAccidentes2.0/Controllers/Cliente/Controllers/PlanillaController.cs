using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Cliente.Controllers
{

    [Authorize]

    public class PlanillaController : Controller
    {
        // GET: Planilla
        public ActionResult Index()
        {
            //string id = System.Web.HttpContext.Current.Session["sessionId"] as string;
            //int ide = Convert.ToInt32(id);
            // = ViewData["sessionId"].ToString();
            //Client u = new Client().find(ide);
            //int rut = u.rut;
            //Console.WriteLine(rut);
            ViewBag.plani = new Planilla().ReadAll();
            return View();
        }
        // GET: Usuario/Create
        private void enviarcli() {
            ViewBag.cli = new Client().ReadAll();
        }

        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Descripcion,rut_cliente")] Planilla planilla)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(planilla);
                }
                // TODO: Add insert logic here
                planilla.Save();
                

                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(planilla);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {

            Planilla u = new Planilla().find(id);
            if (u == null)
            {
                TempData["mensaje"] = "La planilla no existe";
                return RedirectToAction("Index");
            }
            return View(u);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_planilla,Descripcion")] Planilla planilla)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(planilla);
                }
                planilla.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "No se ha modificado";
                return View(planilla);
            }
        }
    }
}