using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NomasAccidentes2._0.Negocio;

namespace NoMasAccidentes2._0.Controllers.Admin.Controllers
{
    [Authorize ]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.Usuario = new Usuario().ReadAll();
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {

            EnviarRol();
            EnviarEstadousr();
            return View();
        }
        private void EnviarEstadousr()
        {
            ViewBag.uestado = new Uestado().ReadAll();
        }
        private void EnviarRol()
        {
            ViewBag.rol = new Rol().ReadAll();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Nombre,Contrasena,Id_rol, Id_estado")] Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarRol();
                    EnviarEstadousr();
                    return View(usuario);
                }
                // TODO: Add insert logic here
                if (usuario.Id_rol == 1) { 
                usuario.Save();
                }
                if (usuario.Id_rol == 2) {
                    usuario.Saveclien();
                }
                if (usuario.Id_rol == 3) { 
                    usuario.Saveprof();
                }
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {

            Usuario u = new Usuario().find(id);
            if (u == null) {
                TempData["mensaje"] = "El usuario no existe";
                return RedirectToAction("Index");
            }
            EnviarRol();
            EnviarEstadousr();

            return View(u);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Contrasena,Id_rol, Id_estado")] Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    EnviarRol();
                    EnviarEstadousr();
                    return View(usuario);
                }
                usuario.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "No se ha modificado";
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Usuario().find(id)==null) {
                TempData["mensaje"] = "No existe el usuario";
                return RedirectToAction("Index");
            }
            if (new Usuario().Delete(id))
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
