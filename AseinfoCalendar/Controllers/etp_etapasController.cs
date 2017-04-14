using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AseinfoCalendar.Models;

namespace AseinfoCalendar.Controllers
{
    public class etp_etapasController : Controller
    {
        private AseCalendarEntities db = new AseCalendarEntities();

        // GET: etp_etapas
        public ActionResult Index()
        {
            var etp_etapas = db.etp_etapas.Include(e => e.pln_plan);
            return View(etp_etapas.ToList());
        }

        // GET: etp_etapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etp_etapas etp_etapas = db.etp_etapas.Find(id);
            if (etp_etapas == null)
            {
                return HttpNotFound();
            }
            return View(etp_etapas);
        }

        // GET: etp_etapas/Create
        public ActionResult Create()
        {
            ViewBag.pln_codigo = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre");
            return View();
        }

        // POST: etp_etapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "etp_codigo,etp_nombre,etp_orden,etp_descripciom,etp_objetivo,etp_usuario_creacion,etp_fecha_grabacion,pln_codigo,etp_fecha_inicio,etp_fecha_fin")] etp_etapas etp_etapas)
        {
            if (ModelState.IsValid)
            {
                db.etp_etapas.Add(etp_etapas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pln_codigo = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre", etp_etapas.pln_codigo);
            return View(etp_etapas);
        }

        // GET: etp_etapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etp_etapas etp_etapas = db.etp_etapas.Find(id);
            if (etp_etapas == null)
            {
                return HttpNotFound();
            }
            ViewBag.pln_codigo = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre", etp_etapas.pln_codigo);
            return View(etp_etapas);
        }

        // POST: etp_etapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "etp_codigo,etp_nombre,etp_orden,etp_descripciom,etp_objetivo,etp_usuario_creacion,etp_fecha_grabacion,pln_codigo,etp_fecha_inicio,etp_fecha_fin")] etp_etapas etp_etapas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etp_etapas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pln_codigo = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre", etp_etapas.pln_codigo);
            return View(etp_etapas);
        }

        // GET: etp_etapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etp_etapas etp_etapas = db.etp_etapas.Find(id);
            if (etp_etapas == null)
            {
                return HttpNotFound();
            }
            return View(etp_etapas);
        }

        // POST: etp_etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            etp_etapas etp_etapas = db.etp_etapas.Find(id);
            db.etp_etapas.Remove(etp_etapas);
            db.SaveChanges();
            return RedirectToAction("Index");
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
