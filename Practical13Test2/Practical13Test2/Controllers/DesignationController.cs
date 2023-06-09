using Practical13Test2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Practical13Test2.Controllers
{
    public class DesignationController : Controller
    {
        private ContextClass db = new ContextClass();

        // GET: Designation
        public ActionResult Index()
        {
            return View(db.designations.ToList());
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designations designations = db.designations.Find(id);
            if (designations == null)
            {
                return HttpNotFound();
            }
            return View(designations);


        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Designation")] Designations designations)
        {
            if (ModelState.IsValid)
            {
                db.designations.Add(designations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designations designation= db.designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Designation")] Designations designations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designations);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designations designation = db.designations.Find(id);
            if (designation== null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designations designation= db.designations.Find(id);
            db.designations.Remove(designation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}