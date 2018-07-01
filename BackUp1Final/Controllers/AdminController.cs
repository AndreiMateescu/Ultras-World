using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackUp1Final.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogs()
        {
            return View(context.Logins.OrderByDescending(s => s.Id).ToList());
        }

        public ActionResult GetUsers()
        {
            var context = new Models.ApplicationDbContext();

            var users = context.Users.ToList();

            return View(users);
        }
    }
}