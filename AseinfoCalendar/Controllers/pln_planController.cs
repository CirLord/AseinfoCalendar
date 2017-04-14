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
    public class pln_planController : Controller
    {
        private AseCalendarEntities db = new AseCalendarEntities();

        // GET: pln_plan
        public ActionResult Index()
        {
            return View(db.pln_plan.ToList());
        }

        // GET: pln_plan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln_plan pln_plan = db.pln_plan.Find(id);
            if (pln_plan == null)
            {
                return HttpNotFound();
            }
            return View(pln_plan);
        }

        // GET: pln_plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pln_plan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pln_codigo,pln_nombre,pln_descripcion,pln_objetivo,pln_usuario_creacion,pln_fecha_creacion,pln_codigo_visual")] pln_plan pln_plan)
        {
            if (ModelState.IsValid)
            {
                db.pln_plan.Add(pln_plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pln_plan);
        }

        // GET: pln_plan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln_plan pln_plan = db.pln_plan.Find(id);
            if (pln_plan == null)
            {
                return HttpNotFound();
            }
            return View(pln_plan);
        }

        // POST: pln_plan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pln_codigo,pln_nombre,pln_descripcion,pln_objetivo,pln_usuario_creacion,pln_fecha_creacion,pln_codigo_visual")] pln_plan pln_plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pln_plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pln_plan);
        }

        // GET: pln_plan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln_plan pln_plan = db.pln_plan.Find(id);
            if (pln_plan == null)
            {
                return HttpNotFound();
            }
            return View(pln_plan);
        }

        // POST: pln_plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pln_plan pln_plan = db.pln_plan.Find(id);
            db.pln_plan.Remove(pln_plan);
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
