using Practical13Test2.Models;
using Practical13Test2.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Practical13Test2.Controllers
{
    public class EmployeeController : Controller
    {

        private ContextClass db = new ContextClass();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.employees.Include(c => c.Designations).ToList());
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);


        }

        public ActionResult Create()
        {
            var viewmodel = new EmployeeDesignationViewModel
            {

                Designation = db.designations.ToList()
            };

            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {


            if (!ModelState.IsValid)
            {

                var viewModel = new EmployeeDesignationViewModel
                {
                    Employee = employee,
                    Designation = db.designations.ToList()
                };
                return View(viewModel);

            }

            db.employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index", db.employees.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();


            }
            var viewModel = new EmployeeDesignationViewModel
            {
                Employee = employee,
                Designation = db.designations.ToList()
            };

            return View(viewModel);

        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeDesignationViewModel
            {
                Employee = employee,
                Designation = db.designations.ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult empcount()
        //{

        //    var count = db.employees.Include(e=>e.Designations).GroupBy(e=>e.Designations.Designation)
        //        .Select(g=> new { Name = g.Key,count =g.Count() }).ToList();

        //    ViewBag.count=count;
        //    return View();

        //}

        public ActionResult Empcount() {
            
            
            var count = db.employees.Include(e => e.Designations).GroupBy(e => e.Designations.Designation)
                  .Select(g => new  Countemp { name = g.Key, sum = g.Count() });

            
            return View(count);



        }

    }
}