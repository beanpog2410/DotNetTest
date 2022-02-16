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
    [Authorize(Roles = "admin", Users = "admin@gmail.com")]
    public class userController : Controller
    {
        private Default_Entities db = new Default_Entities();
        private MULTIPLE_CHOICE_Entities db2 = new MULTIPLE_CHOICE_Entities();

        // GET: user
        public ActionResult Index()
        {
            var listUser = new List<InfoUser>();
            using (db)
            {
                listUser = (from u in db.AspNetUsers
                            where u.Email != "admin@gmail.com"
                            select new InfoUser
                            {
                                Id = u.Id,
                                Email = u.Email,
                            }).ToList();
            }
            return View(listUser);
        }

        // GET: user/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db2.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}