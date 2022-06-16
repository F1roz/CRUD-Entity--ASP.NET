using CRUD_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Entity.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var db = new WebEntities();
            var users = db.Users;
            return View(users);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(User us)
        {
            var db = new WebEntities();
            db.Users.Add(us);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new WebEntities();
            var user = (from u in db.Users where u.Id == id select u).SingleOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User us)
        {
            var db = new WebEntities();
            if (ModelState.IsValid)
            {
                db.Entry(us).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(us);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new WebEntities();
            var user = (from u in db.Users where u.Id == id select u).SingleOrDefault();
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var db = new WebEntities();
            var user = (from u in db.Users where u.Id == id select u).SingleOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}