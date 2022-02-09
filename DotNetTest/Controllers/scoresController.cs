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
    }
}
