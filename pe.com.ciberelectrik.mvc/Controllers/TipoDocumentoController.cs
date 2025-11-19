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
    public class TipoDocumentoController : Controller
    {
        //creamos un objeto del contexto
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View(db.tipodocumento.ToList());
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipodocumento);
            }
        }

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipodocumento);
            }
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipodocumento);
            }
        }

        // GET: TipoDocumento/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipodocumento);
            }
        }

        //acciones -> Post
        // POST: TipoDocumento/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre,estado")] TipoDocumento obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tipodocumento.Add(obj);
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

        // POST: TipoDocumento/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre,estado")] TipoDocumento obj)
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

        // POST: TipoDocumento/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo,nombre,estado")] TipoDocumento obj)
        {
            try
            {
                var tipodocumento = db.tipodocumento.Find(id);
                if (tipodocumento != null)
                {
                    tipodocumento.estado = false;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: TipoDocumento/Enable/5
        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo,nombre,estado")] TipoDocumento obj)
        {
            try
            {
                var tipodocumento = db.tipodocumento.Find(id);
                if (tipodocumento != null)
                {
                    tipodocumento.estado = true;
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
