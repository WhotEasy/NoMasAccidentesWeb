using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoMasAccidentes2._0.Controllers.Cliente.Controllers
{
    [Authorize]
    public class SolicitudClienteController : Controller
    {
        // GET: SolicitudCliente
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.Solicitudes = new Solicitudes().ReadAll();
            return View();
        }

        /* GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        */
        // GET: Usuario/Create
        public ActionResult Create()
        {

            EnviarSolici();
            Enviarestado();
            //Enviarcli();
            return View();
        }

        private void EnviarSolici()
        {
            ViewBag.estado = new EstadoSol().ReadAll();
        }
        private void Enviarestado()
        {
            ViewBag.tipo = new Tiposol().ReadAll();
        }
        //private void Enviarcli()
        //{
        //    ViewBag.cli = new Cliente().
        //}
        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "RUT_CLIENTE,ID_TIPO_SOLICITUDES,FECHA_SOLICITUD, Id_estado")] Solicitudes solicitud)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarSolici();
                    Enviarestado();
                    return View(solicitud);
                }
                // TODO: Add insert logic here
                solicitud.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(solicitud);
            }
        }
        
    }
}