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
    public class pls_planeacion_semanalController : Controller
    {
        private AseCalendarEntities db = new AseCalendarEntities();

        // GET: pls_planeacion_semanal
        public ActionResult Index()
        {
            var pls_planeacion_semanal = db.pls_planeacion_semanal.Include(p => p.etp_etapas).Include(p => p.pln_plan);
            return View(pls_planeacion_semanal.ToList());
        }

        // GET: pls_planeacion_semanal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pls_planeacion_semanal pls_planeacion_semanal = db.pls_planeacion_semanal.Find(id);
            if (pls_planeacion_semanal == null)
            {
                return HttpNotFound();
            }
            return View(pls_planeacion_semanal);
        }

        // GET: pls_planeacion_semanal/Create
        public ActionResult Create()
        {
            ViewBag.pls_codetp = new SelectList(db.etp_etapas, "etp_codigo", "etp_nombre");
            ViewBag.pls_codpln = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre");
            return View();
        }

        // POST: pls_planeacion_semanal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pls_codigo,pls_codpln,pls_codetp,pls_descripcion,pls_fecha,pls_hora_desde,pls_hora_hasta")] pls_planeacion_semanal pls_planeacion_semanal)
        {
            if (ModelState.IsValid)
            {
                pls_planeacion_semanal.pls_fecha_creacion = DateTime.Today;
                pls_planeacion_semanal.pls_cancelado = 0;
                db.pls_planeacion_semanal.Add(pls_planeacion_semanal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pls_codetp = new SelectList(db.etp_etapas, "etp_codigo", "etp_nombre", pls_planeacion_semanal.pls_codetp);
            ViewBag.pls_codpln = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre", pls_planeacion_semanal.pls_codpln);
            return View(pls_planeacion_semanal);
        }

        // GET: pls_planeacion_semanal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pls_planeacion_semanal pls_planeacion_semanal = db.pls_planeacion_semanal.Find(id);
            if (pls_planeacion_semanal == null)
            {
                return HttpNotFound();
            }
            ViewBag.pls_codetp = new SelectList(db.etp_etapas, "etp_codigo", "etp_nombre", pls_planeacion_semanal.pls_codetp);
            ViewBag.pls_codpln = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre", pls_planeacion_semanal.pls_codpln);
            return View(pls_planeacion_semanal);
        }

        // POST: pls_planeacion_semanal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pls_codigo,pls_codpln,pls_codetp,pls_descripcion,pls_fecha,pls_hora_desde,pls_hora_hasta,pls_usuario_creacion,pls_fecha_creacion,pls_cancelado,pls_descripcion_cancelacion")] pls_planeacion_semanal pls_planeacion_semanal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pls_planeacion_semanal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pls_codetp = new SelectList(db.etp_etapas, "etp_codigo", "etp_nombre", pls_planeacion_semanal.pls_codetp);
            ViewBag.pls_codpln = new SelectList(db.pln_plan, "pln_codigo", "pln_nombre", pls_planeacion_semanal.pls_codpln);
            return View(pls_planeacion_semanal);
        }

        // GET: pls_planeacion_semanal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pls_planeacion_semanal pls_planeacion_semanal = db.pls_planeacion_semanal.Find(id);
            if (pls_planeacion_semanal == null)
            {
                return HttpNotFound();
            }
            return View(pls_planeacion_semanal);
        }

        // POST: pls_planeacion_semanal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pls_planeacion_semanal pls_planeacion_semanal = db.pls_planeacion_semanal.Find(id);
            db.pls_planeacion_semanal.Remove(pls_planeacion_semanal);
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
