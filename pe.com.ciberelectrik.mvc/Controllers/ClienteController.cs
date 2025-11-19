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
    public class ClienteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cliente
        public ActionResult Index()
        {
            var lista = db.cliente
                .Include(c => c.distrito)
                .Include(c => c.TipoDocumento)
                .Include(c => c.sexo)
                .ToList();

            return View(lista);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre");
            ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre");
            ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre");

            return View();
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = db.cliente.Find(id);
            if (cliente == null)
                return HttpNotFound();

            ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre", cliente.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre", cliente.codtipd);
            ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre", cliente.codsex);

            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult DeleteConfirmado(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = db.cliente
                .Include(c => c.distrito)
                .Include(c => c.TipoDocumento)
                .Include(c => c.sexo)
                .FirstOrDefault(c => c.codigo == id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {   
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = db.cliente
                .Include(c => c.distrito)
                .Include(c => c.TipoDocumento)
                .Include(c => c.sexo)
                .FirstOrDefault(c => c.codigo == id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // GET: Cliente/Enable/5
        public ActionResult EnableConfirm(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = db.cliente
                .Include(c => c.distrito)
                .Include(c => c.TipoDocumento)
                .Include(c => c.sexo)
                .FirstOrDefault(c => c.codigo == id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
            "nombre,apellidopaterno,apellidomaterno,numerodocumento,direccion,telefono,celular,correo,estado,coddis,codtipd,codsex"
        )] Cliente obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.cliente.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre", obj.coddis);
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre", obj.codtipd);
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre", obj.codsex);

                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                
                ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre");
                
                return View(obj);
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
            "codigo,nombre,apellidopaterno,apellidomaterno,numerodocumento,direccion,telefono,celular,correo,estado,coddis,codtipd,codsex"
        )] Cliente obj)
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
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre", obj.codtipd);
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre", obj.codsex);

                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                
                ViewBag.coddis = new SelectList(db.distrito.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codtipd = new SelectList(db.tipodocumento.Where(x => x.estado), "codigo", "nombre");
                ViewBag.codsex = new SelectList(db.sexo.Where(x => x.estado), "codigo", "nombre");
                
                return View(obj);
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var cliente = db.cliente.Find(id);
                if (cliente != null)
                {
                    cliente.estado = false;
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

        // POST: Cliente/Enable/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enable(int? id)
        {
            try
            {
                var cliente = db.cliente.Find(id);
                if (cliente != null)
                {
                    cliente.estado = true;
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
