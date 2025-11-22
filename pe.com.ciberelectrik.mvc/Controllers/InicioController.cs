using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pe.com.ciberelectrik.mvc.Models;
using pe.com.ciberelectrik.mvc.Models.db;

namespace pe.com.ciberelectrik.mvc.Controllers
{
    public class InicioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        // POST: Inicio/ValidarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidarUsuario(string usuario, string clave)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                ViewBag.Mensaje = "Debe ingresar usuario y clave";
                return View("Index");
            }

            // Buscar el empleado en la base de datos
            var empleado = db.empleado.FirstOrDefault(e => e.usuario == usuario && e.clave == clave);

            // Validar si existe el empleado y está activo
            if (empleado == null)
            {
                ViewBag.Mensaje = "Usuario o clave incorrectos";
                return View("Index");
            }

            if (!empleado.estado)
            {
                ViewBag.Mensaje = "Usuario inactivo";
                return View("Index");
            }

            // Guardar el empleado en sesión
            Session["empleado"] = empleado;

            // Redirigir al inicio del sistema
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}