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
    public class answersController : Controller
    {
        private MULTIPLE_CHOICE_Entities db = new MULTIPLE_CHOICE_Entities();

        // GET: answers
        public ActionResult Index()
        {
            var answers = db.answers.Include(a => a.question);
            return View(answers.ToList());
        }

        // GET: answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            answer answer = db.answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: answers/Create
        public ActionResult Create()
        {
            ViewBag.question_id = new SelectList(db.questions, "id", "content");
            return View();
        }

        // POST: answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,content,is_true,created_date,updated_date,question_id")] answer answer)
        {
            if (ModelState.IsValid)
            {
                db.answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.question_id = new SelectList(db.questions, "id", "content", answer.question_id);
            return View(answer);
        }

        // GET: answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            answer answer = db.answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.question_id = new SelectList(db.questions, "id", "content", answer.question_id);
            return View(answer);
        }

        // POST: answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,content,is_true,created_date,updated_date,question_id")] answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.question_id = new SelectList(db.questions, "id", "content", answer.question_id);
            return View(answer);
        }

        // GET: answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            answer answer = db.answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            answer answer = db.answers.Find(id);
            db.answers.Remove(answer);
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
