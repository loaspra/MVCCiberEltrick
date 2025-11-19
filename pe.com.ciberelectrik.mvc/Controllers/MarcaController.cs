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
    public class MarcaController : Controller
    {
        //creamos un objeto del contexto
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Marca
        public ActionResult Index()
        {
            return View(db.marca.ToList());
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        // GET: Marca/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        //acciones -> Post
        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre,estado")] Marca obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.marca.Add(obj);
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

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre,estado")] Marca obj)
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

        // POST: Marca/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo,nombre,estado")] Marca obj)
        {
            try
            {
                var marca = db.marca.Find(id);
                if (marca != null)
                {
                    marca.estado = false;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Marca/Enable/5
        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo,nombre,estado")] Marca obj)
        {
            try
            {
                var marca = db.marca.Find(id);
                if (marca != null)
                {
                    marca.estado = true;
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
