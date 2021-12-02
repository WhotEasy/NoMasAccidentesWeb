using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Profesional.Controllers
{
    [Authorize]

    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            ViewBag.info = new Informe().ReadAll();
            return View();
        }
        public ActionResult Create()
        {

            enviarplanilla(); 
            enviarestado();
            enviarCli();

            return View();
        }
        private void enviarplanilla()
        {
            ViewBag.plani = new Planilla().ReadAll();
        }
        private void enviarestado()
        {
            ViewBag.estad = new EstadoInforme().ReadAll();
        }
        private void enviarCli()
        {
            ViewBag.cli = new Client().ReadAll();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "DESCRIPCION, ID_ESTADO_INFO, ID_PLANILLA, RUT_CLIENTE, RUT_PROFESIONAL")] Informe informe)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    enviarplanilla();
                    enviarestado();
                    enviarCli();

                    return View(informe);
                }
                // TODO: Add insert logic here

                informe.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(informe);
            }
        }
        public ActionResult Edit(int id)
        {

            Informe u = new Informe().find(id);
            if (u == null)
            {
                TempData["mensaje"] = "El usuario no existe";
                return RedirectToAction("Index");
            }
            enviarplanilla();
            enviarestado();


            return View(u);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_informe, DESCRIPCION, ID_ESTADO_INFO, Rut_profesional, Rut_cliente, ID_PLANILLA")] Informe informe)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    enviarplanilla();
                    enviarestado();

                    return View(informe);
                }
                informe.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "No se ha modificado";
                return View(informe);
            }
        }
    }
}