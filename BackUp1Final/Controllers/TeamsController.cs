using BackUp1Final.Data;
using BackUp1Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BackUp1Final.Controllers
{
    public class TeamsController : Controller
    {
        private TeamRepository _teamRepository = null;

        public TeamsController()
        {
            _teamRepository = new TeamRepository();
        }

        // GET: Teams
        [Authorize]
        public ActionResult Teams()
        {
            var teams = _teamRepository.GetTeams();

            return View(teams);
        }

        // GET: Team
        [Authorize]
        public ActionResult Team(int? id)
        {
            if (id == null || id > _teamRepository.GetLastId() || !_teamRepository.ExistsId(id.Value))
            {
                return HttpNotFound();
            }

            var team = _teamRepository.GetTeam(id.Value);

            return View(team);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddTeam()
        {
            var team = new Team()
            {
                FoundingDate = DateTime.Today
            };
            

            return View(team);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddTeam(Team team)
        { 
            if (ModelState.IsValid)
            {
                _teamRepository.Add(team);

                TempData["Message"] = "The team was successfully added!";

                return RedirectToAction("Teams");
            }

            return View(team);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditTeam(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var team = _teamRepository.GetTeam(id.Value);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                _teamRepository.Update(team);

                TempData["Message"] = "The team was successfully edited!";

                return RedirectToAction("Teams");
            }

            return View(team);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTeam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var team = _teamRepository.GetTeam(id.Value);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteTeam(int id)
        {
            _teamRepository.Delete(id);

            TempData["Message"] = "The team was successfully deleted!";

            return RedirectToAction("Teams");
        }
    }
}