using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DotNetTest.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationUserManager UserManager;
        public ActionResult Index()
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());

            return View();
        }

       
    }
}