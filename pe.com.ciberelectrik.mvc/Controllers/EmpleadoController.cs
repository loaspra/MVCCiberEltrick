using pe.com.ciberelectrik.mvc.Models;
using pe.com.ciberelectrik.mvc.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace pe.com.ciberelectrik.mvc.Controllers
{
    public class EmpleadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empleado
        public ActionResult Index()
        {
            var lista = db.empleado
                .Include(e => e.distrito)
                .Include(e => e.rol)
                .Include(e => e.TipoDocumento)
                .Include(e => e.sexo)
                .ToList();

            return View(lista);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre");
            ViewBag.codrol = new SelectList(db.rol.Where(x => x.estado), "codigo", "nombre");
            ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre");
            ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre");

            return View();
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empleado = db.empleado.Find(id);
            if (empleado == null)
                return HttpNotFound();

            ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol.Where(x => x.estado), "codigo", "nombre", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre", empleado.codtipd);
            ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre", empleado.codsex);

            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empleado = db.empleado
                .Include(e => e.distrito)
                .Include(e => e.rol)
                .Include(e => e.TipoDocumento)
                .Include(e => e.sexo)
                .FirstOrDefault(e => e.codigo == id);

            if (empleado == null)
                return HttpNotFound();

            return View(empleado);
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empleado = db.empleado
                .Include(e => e.distrito)
                .Include(e => e.rol)
                .Include(e => e.TipoDocumento)
                .Include(e => e.sexo)
                .FirstOrDefault(e => e.codigo == id);

            if (empleado == null)
                return HttpNotFound();

            return View(empleado);
        }

        // GET: Empleado/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empleado = db.empleado
                .Include(e => e.distrito)
                .Include(e => e.rol)
                .Include(e => e.TipoDocumento)
                .Include(e => e.sexo)
                .FirstOrDefault(e => e.codigo == id);

            if (empleado == null)
                return HttpNotFound();

            return View(empleado);
        }

        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
            "nombre,apellidopaterno,apellidomaterno,numerodocumento,direccion,telefono,celular,correo,usuario,clave,estado,coddis,codrol,codtipd,codsex"
        )] Empleado obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.empleado.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre", obj.coddis);
                ViewBag.codrol = new SelectList(db.rol.Where(x => x.estado), "codigo", "nombre", obj.codrol);
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre", obj.codtipd);
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre", obj.codsex);

                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codrol = new SelectList(db.rol.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre");

                return View(obj);
            }
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
            "codigo,nombre,apellidopaterno,apellidomaterno,numerodocumento,direccion,telefono,celular,correo,usuario,clave,estado,coddis,codrol,codtipd,codsex"
        )] Empleado obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre", obj.coddis);
                ViewBag.codrol = new SelectList(db.rol.Where(x => x.estado), "codigo", "nombre", obj.codrol);
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre", obj.codtipd);
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre", obj.codsex);

                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codrol = new SelectList(db.rol.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre");

                return View(obj);
            }
        }

        // POST: Empleado/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                var empleado = db.empleado.Find(id);
                if (empleado != null)
                {
                    empleado.estado = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return RedirectToAction("Index");
            }
        }

        // POST: Empleado/Enable/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Enable")]
        public ActionResult EnableConfirmed(int? id)
        {
            try
            {
                var empleado = db.empleado.Find(id);
                if (empleado != null)
                {
                    empleado.estado = true;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
