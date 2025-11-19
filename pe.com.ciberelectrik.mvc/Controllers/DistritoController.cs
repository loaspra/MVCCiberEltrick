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
    public class DistritoController : Controller
    {
        //creamos un objeto del contexto
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Distrito
        public ActionResult Index()
        {
            return View(db.distrito.ToList());
        }

        // GET: Distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        // GET: Distrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        // GET: Distrito/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        //acciones -> Post
        // POST: Distrito/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre,estado")] Distrito obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.distrito.Add(obj);
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

        // POST: Distrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre,estado")] Distrito obj)
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

        // POST: Distrito/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo,nombre,estado")] Distrito obj)
        {
            try
            {
                var distrito = db.distrito.Find(id);
                if (distrito != null)
                {
                    distrito.estado = false;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Distrito/Enable/5
        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo,nombre,estado")] Distrito obj)
        {
            try
            {
                var distrito = db.distrito.Find(id);
                if (distrito != null)
                {
                    distrito.estado = true;
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
