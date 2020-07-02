using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3.Models;
using TP3.Models.Identity.Models;

namespace TP3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        ApplicationDbContext identity;

        public AdministrationController()
        {
            identity = new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult Utilisateurs()
        {
            var users = identity.Users;
            return View(users);
        }

        [HttpPost]
        public ActionResult UserCreate(UserInfo userInfo)
        {
            var store = new UserStore<ApplicationUser>(identity);
            var manager = new ApplicationUserManager(store);
            var user = new ApplicationUser() { Email = userInfo.Email, UserName = userInfo.Email };
            manager.Create(user, userInfo.Password);
            return RedirectToAction("Utilisateurs");
        }

        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserDelete(String id)
        {
            var store = new UserStore<ApplicationUser>(identity);
            var manager = new ApplicationUserManager(store);
            var user = manager.FindById(id);
            manager.Delete(user);
            return RedirectToAction("Utilisateurs");
        }

        [HttpGet]
        public ActionResult UserEdit(string id)
        {
            ApplicationUser user = identity.Users.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(ApplicationUser user)
        {
            identity.Entry(user).State = EntityState.Modified;
            identity.SaveChanges();
            return RedirectToAction("Utilisateurs");
        }
        
    }

}