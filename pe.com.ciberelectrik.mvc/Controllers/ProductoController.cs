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
    public class ProductoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Producto
        public ActionResult Index()
        {
            var lista = db.producto
                .Include(p => p.categoria)
                .Include(p => p.marca)
                .ToList();

            return View(lista);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.codcat = new SelectList(db.categoria.Where(x => x.estado), "codigo", "nombre");
            ViewBag.codmar = new SelectList(db.marca.Where(x => x.estado), "codigo", "nombre");
            return View();
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.codcat = new SelectList(db.categoria.Where(x => x.estado), "codigo", "nombre", producto.codcat);
                ViewBag.codmar = new SelectList(db.marca.Where(x => x.estado), "codigo", "nombre", producto.codmar);
                return View(producto);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.producto
                .Include(p => p.categoria)
                .Include(p => p.marca)
                .FirstOrDefault(p => p.codigo == id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(producto);
            }
        }

        // GET: Producto/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.producto
                .Include(p => p.categoria)
                .Include(p => p.marca)
                .FirstOrDefault(p => p.codigo == id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(producto);
            }
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.producto
                .Include(p => p.categoria)
                .Include(p => p.marca)
                .FirstOrDefault(p => p.codigo == id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(producto);
            }
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,descripcion,precio,cantidad,fechaingreso,estado,codmar,codcat")] Producto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.producto.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.codcat = new SelectList(db.categoria.Where(x => x.estado), "codigo", "nombre", obj.codcat);
                ViewBag.codmar = new SelectList(db.marca.Where(x => x.estado), "codigo", "nombre", obj.codmar);
                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                ViewBag.codcat = new SelectList(db.categoria.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codmar = new SelectList(db.marca.Where(x => x.estado), "codigo", "nombre");
                return View(obj);
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,descripcion,precio,cantidad,fechaingreso,estado,codmar,codcat")] Producto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.codcat = new SelectList(db.categoria.Where(x => x.estado), "codigo", "nombre", obj.codcat);
                ViewBag.codmar = new SelectList(db.marca.Where(x => x.estado), "codigo", "nombre", obj.codmar);
                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                ViewBag.codcat = new SelectList(db.categoria.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codmar = new SelectList(db.marca.Where(x => x.estado), "codigo", "nombre");
                return View(obj);
            }
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                var producto = db.producto.Find(id);
                if (producto != null)
                {
                    producto.estado = false;
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

        // POST: Producto/Enable/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Enable")]
        public ActionResult EnableConfirmed(int? id)
        {
            try
            {
                var producto = db.producto.Find(id);
                if (producto != null)
                {
                    producto.estado = true;
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
