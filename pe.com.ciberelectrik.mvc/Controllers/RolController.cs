using pe.com.ciberelectrik.mvc.Models;
using pe.com.ciberelectrik.mvc.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pe.com.ciberelectrik.mvc.Controllers
{
    public class RolController : Controller
    {
        //creamos un objeto del contexto
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rol
        public ActionResult Index()
        {
            return View(db.rol.ToList());
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Rol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        // GET: Rol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        // GET: Rol/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        //acciones -> Post
        // POST: Rol/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre,estado")] Rol obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.rol.Add(obj);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return View();
            }
        }

        // POST: Rol/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre,estado")] Rol obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch
            {
                return View();
            }
        }

        // POST: Rol/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo,nombre,estado")] Rol obj)
        {
            try
            {
                var rol = db.rol.Find(id);
                if (rol != null)
                {
                    rol.estado = false;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Rol/Enable/5
        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo,nombre,estado")] Rol obj)
        {
            try
            {
                var rol = db.rol.Find(id);
                if (rol != null)
                {
                    rol.estado = true;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
