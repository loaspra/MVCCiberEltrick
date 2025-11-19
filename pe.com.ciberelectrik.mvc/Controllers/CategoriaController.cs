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
    public class CategoriaController : Controller
    {
        //creamos un objeto del contexto
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categoria
        //[HttpGet] -> se entiende por defecto
        //primero manejos rutas -> GET
        public ActionResult Index()
        {
            return View(db.categoria.ToList());
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        // GET: Categoria/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        //acciones -> Post
        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre,estado")] Categoria obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.categoria.Add(obj);
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

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre,estado")] Categoria obj)
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



        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo,nombre,estado")] Categoria obj)
        {
            try
            {
                //eliminacion fisica -> no se utiliza
                //db.categoria.Remove(obj);
                //db.SaveChanges
                var categoria = db.categoria.Find(id);
                if (categoria != null)
                {
                    categoria.estado = false;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo,nombre,estado")] Categoria obj)
        {
            try
            {
                //eliminacion fisica -> no se utiliza
                //db.categoria.Remove(obj);
                //db.SaveChanges
                var categoria = db.categoria.Find(id);
                if (categoria != null)
                {
                    categoria.estado = true;
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
