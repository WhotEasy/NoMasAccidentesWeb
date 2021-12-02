using NomasAccidentes2._0.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NoMasAccidentes2._0.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario, string ReturnUrl) {
            if (IsValid(usuario)){
                FormsAuthentication.SetAuthCookie(usuario.Nombre, false);
                if (ReturnUrl != null ){
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Inicio", "HomeAdmin");
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