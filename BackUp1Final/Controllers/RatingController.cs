using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackUp1Final.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Vote()
        {
            return View();
        }
    }
}