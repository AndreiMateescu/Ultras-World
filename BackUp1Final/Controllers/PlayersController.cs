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
    public class PlayersController : Controller
    {
        private PlayerRepository _playerRepository = null;
        
        public PlayersController()
        {
            _playerRepository = new PlayerRepository();
        }

        // GET: Players
        [Authorize]
        public ActionResult Players()
        {
            var players = _playerRepository.GetPlayers();

            return View(players);
        }

        [Authorize]
        public ActionResult Player(int? id)
        {
            if(id == null || id > _playerRepository.GetLastId() || _playerRepository.ExistsId(id.Value))
            {
                return HttpNotFound();
            }

            var player = _playerRepository.GetPlayer(id.Value);

            return View(player);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddPlayer()
        {
            var player = new Player()
            {
                BirthDate = DateTime.Today
            };

            return View(player);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerRepository.Add(player);

                TempData["Message"] = "The player was successfully added!";

                return RedirectToAction("Players");
            }

            return View(player);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditPlayer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var player = _playerRepository.GetPlayer(id.Value);

            if(player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditPlayer(Player player)
        {
            if(ModelState.IsValid)
            {
                _playerRepository.Update(player);
                TempData["Message"] = "The player was successfully edited!";

                return RedirectToAction("Players");
            }

            return View(player);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeletePlayer(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var player = _playerRepository.GetPlayer(id.Value);

            if(player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeletePlayer(int id)
        {
            _playerRepository.Delete(id);

            TempData["Message"] = "The player was successfully deleted!";

            return RedirectToAction("Players");
        }
    }
}