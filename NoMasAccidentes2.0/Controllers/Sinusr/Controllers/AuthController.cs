using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NoMasAccidentes2._0.Controllers.Sinusr.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario, string nombre ) {
            
            if (IsValid(usuario)){
                FormsAuthentication.SetAuthCookie(usuario.Nombre, false);
                /*if (ReturnUrl != null ){
                    return Redirect(ReturnUrl);
                }*/
                Usuario u = new Usuario().found(nombre);
                if (u.Id_rol == 1 && u.Id_estado==1)
                {
                    System.Web.HttpContext.Current.Session["sessionName"] = u.Nombre;
                    System.Web.HttpContext.Current.Session["sessionId"] = u.Id;
                    return RedirectToAction("Inicio", "HomeAdmin");
                }
                else if (u.Id_rol == 2 && u.Id_estado == 1)
                {
                    System.Web.HttpContext.Current.Session["sessionName"] = u.Nombre;
                    System.Web.HttpContext.Current.Session["sessionId"] = u.Id;
                    return RedirectToAction("Index", "HomeCliente");
                }
                else if (u.Id_rol == 3 && u.Id_estado == 1)
                {
                    System.Web.HttpContext.Current.Session["sessionName"] = u.Nombre;
                    System.Web.HttpContext.Current.Session["sessionId"] = u.Id;
                    return RedirectToAction("Index", "HomeProfesional");
                }

            }
            TempData["mensaje"] = "Credenciales Invalidas";
            return View(usuario);
        }
        private bool IsValid(Usuario usuario) {
            return usuario.Autenticar();

        }
        public ActionResult LogOut() {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}