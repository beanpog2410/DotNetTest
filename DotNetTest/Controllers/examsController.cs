using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetTest.Models;

namespace DotNetTest.Controllers
{
    public class examsController : Controller
    {
        private MULTIPLE_CHOICE_Entities db = new MULTIPLE_CHOICE_Entities();

        // GET: exams
        public ActionResult Index()
        {
            var exams = db.exams.Include(e => e.subject).Include(e => e.user);
            return View(exams.ToList());
        }

        // GET: exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: exams/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.subjects, "id", "name");
            ViewBag.users_id = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,execution_time,start_time,expire_time,password,active,created_date,updated_date,subject_id,users_id")] exam exam)
        {
            if (ModelState.IsValid)
            {
                db.exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.subject_id = new SelectList(db.subjects, "id", "name", exam.subject_id);
            ViewBag.users_id = new SelectList(db.users, "id", "username", exam.users_id);
            return View(exam);
        }

        // GET: exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.subjects, "id", "name", exam.subject_id);
            ViewBag.users_id = new SelectList(db.users, "id", "username", exam.users_id);
            return View(exam);
        }

        // POST: exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,execution_time,start_time,expire_time,password,active,created_date,updated_date,subject_id,users_id")] exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.subjects, "id", "name", exam.subject_id);
            ViewBag.users_id = new SelectList(db.users, "id", "username", exam.users_id);
            return View(exam);
        }

        // GET: exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            exam exam = db.exams.Find(id);
            db.exams.Remove(exam);
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
