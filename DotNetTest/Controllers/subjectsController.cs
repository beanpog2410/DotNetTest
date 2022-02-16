using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetTest.Models;
using Microsoft.AspNet.Identity;

namespace DotNetTest.Controllers
{
    [Authorize(Roles = "lecturer,admin", Users = "lecturer@gmail.com,admin@gmail.com")]
    public class subjectsController : Controller
    {
        private MULTIPLE_CHOICE_Entities db = new MULTIPLE_CHOICE_Entities();

        // GET: subjects
        public ActionResult Index()
        {
            //var dataResult = new List<ExamInSubjectModel>();
            //using (db)
            //{
            //    dataResult = (from s in db.subjects
            //                  join e in db.exams
            //                  on s.id equals e.subject_id
            //                  where e.subject_id == 1
            //                  select new ExamInSubjectModel
            //                  {
            //                      ID = e.id,
            //                      NAME = e.name,
            //                      DO_TIME = e.execution_time,
            //                      START_TIME = e.start_time,
            //                      END_TIME = e.expire_time,
            //                      PASS = e.password,
            //                      ACT = e.active,
            //                  }).ToList();
            //}
            //return View(dataResult);
            return View(db.subjects.ToList());
        }

        // GET: subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] subject subject)
        {
            if (ModelState.IsValid)
            {
                db.subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subject subject = db.subjects.Find(id);
            db.subjects.Remove(subject);
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
