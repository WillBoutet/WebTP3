using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExempleAjaxProduit.Models;
using Microsoft.Extensions.Logging;
using TP3.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace TP3.Controllers
{
    public class HomeController : Controller
    {
        FilmDbContext db;
        ApplicationDbContext identity;
        public HomeController()
        {
            db = new FilmDbContext();
            identity = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            ViewBag.NbFilms = db.Films.Count();
            ViewBag.NbUsers = identity.Users.Count();
            return View();
        }
        [Authorize]
        public ActionResult Accueil()
        {
            return View();
        }
        [Authorize]
        public ActionResult Liste()
        {
            ViewBag.Message = "Liste de tous les films : ";
            List<ModelFilm> films = db.Films.ToList();
            return View(films);
        }

        [Authorize]
        public ActionResult MaListe()
        {
            ViewBag.Message = "Mes favoris : ";
            List<ModelFilm> films = new List<ModelFilm>();
            var userId = User.Identity.GetUserId();
            ModelPlaylist playlist = db.Playlists.FirstOrDefault(x => x.IdUser == userId);
            List<ModelPlaylistFilm> lesFilms = db.PlaylistFilms.Where(x => x.Playlist == playlist.Id).ToList();
            foreach (ModelPlaylistFilm film in lesFilms)
            {
                films.Add(db.Films.FirstOrDefault(x => x.Id == film.Film));
            }

            return View(films);
        }

        public ActionResult Echec(string message, string para)
        {
            ViewBag.Para = para;
            ViewBag.Message = message;
            return View();
        }

        [Authorize]
        public ActionResult Film(int id)
        {
            ViewBag.Message = "Page du film : ";
            ViewBag.Filme = db.Films.Where(f => f.Id == id).FirstOrDefault();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddFilm() {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddFilm(ModelFilm film) {
            db.Films.Add(film);

            db.SaveChanges();

            return RedirectToAction("Liste");
        }

        //Passe un id de film en paramete.
        //Rajoute le film dans la playlist du current user.
        public ActionResult Favori(int id,string location)
        {
            var userId = User.Identity.GetUserId();
            ModelPlaylist playlist = db.Playlists.FirstOrDefault(x => x.IdUser == userId);
            try
            {
                var filmExiste = db.PlaylistFilms.First(x => x.Film == id);
                db.PlaylistFilms.Remove(filmExiste);
            }
            catch (Exception e)
            {
                db.PlaylistFilms.Add(new ModelPlaylistFilm(playlist.Id, id));
            }
            db.SaveChanges();

            return RedirectToAction(location);
        }

        [HttpPost]
        public ActionResult Search(string nom)
        {
            ViewBag.Message = "Recherche pour : " + nom;
            List<ModelFilm> liste = db.Films.Where(x => x.Titre.Contains(nom)).ToList();
            return View("Liste", liste);
        }
    }
}