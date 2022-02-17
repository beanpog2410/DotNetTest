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
    public class scoresController : Controller
    {
        private MULTIPLE_CHOICE_Entities db = new MULTIPLE_CHOICE_Entities();

        // GET: scores
        public ActionResult Index()
        {
            var scores = db.scores.Include(s => s.exam).Include(s => s.user);
            return View(scores.ToList());
        }

        // GET: scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            score score = db.scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: scores/Create
        public ActionResult Create()
        {
            ViewBag.exam_id = new SelectList(db.exams, "id", "name");
            ViewBag.users_id = new SelectList(db.users, "id", "name");
            return View();
        }

        // POST: scores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "users_id,exam_id,scores,submited_date")] score score)
        {
            if (ModelState.IsValid)
            {
                db.scores.Add(score);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exam_id = new SelectList(db.exams, "id", "name", score.exam_id);
            ViewBag.users_id = new SelectList(db.users, "id", "name", score.users_id);
            return View(score);
        }

        // GET: scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            score score = db.scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            ViewBag.exam_id = new SelectList(db.exams, "id", "name", score.exam_id);
            ViewBag.users_id = new SelectList(db.users, "id", "name", score.users_id);
            return View(score);
        }

        // POST: scores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "users_id,exam_id,scores,submited_date")] score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.exam_id = new SelectList(db.exams, "id", "name", score.exam_id);
            ViewBag.users_id = new SelectList(db.users, "id", "name", score.users_id);
            return View(score);
        }

        // GET: scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            score score = db.scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            score score = db.scores.Find(id);
            db.scores.Remove(score);
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
