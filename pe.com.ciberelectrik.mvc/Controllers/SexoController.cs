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
    public class SexoController : Controller
    {
        //creamos un objeto del contexto
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sexo
        public ActionResult Index()
        {
            return View(db.sexo.ToList());
        }

        // GET: Sexo/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Sexo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        // GET: Sexo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        // GET: Sexo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        // GET: Sexo/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        //acciones -> Post
        // POST: Sexo/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre,estado")] Sexo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.sexo.Add(obj);
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

        // POST: Sexo/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre,estado")] Sexo obj)
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

        // POST: Sexo/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo,nombre,estado")] Sexo obj)
        {
            try
            {
                var sexo = db.sexo.Find(id);
                if (sexo != null)
                {
                    sexo.estado = false;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Sexo/Enable/5
        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo,nombre,estado")] Sexo obj)
        {
            try
            {
                var sexo = db.sexo.Find(id);
                if (sexo != null)
                {
                    sexo.estado = true;
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
