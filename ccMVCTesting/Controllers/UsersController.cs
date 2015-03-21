using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ccMVCTesting.Model;
using ccMVCTesting.Repository;
using ccMVCTesting.Repository.Interfaces;
using ccMVCTesting.Repository.RealRepository;

namespace ccMVCTesting.Controllers
{
    public class UsersController : Controller
    {
        private IUsersRepository db = null;

        public UsersController()
        {
            db = new UsersRepository(new Entities());
        }

        public UsersController(IUsersRepository usrRepository)
        {
            db = usrRepository;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(db.SelectAll().ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.SelectByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,OriginalEMail,CurrentEMail,Created,Confirmed,LastUpdated,LastLogin,Active,OriginalPwd,CurrentPwd,FailedAttempts,DefaultCurrencyID,OriginalCountryID,LastLoginCountryID,LastFailedCountryID,AuthUserID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Insert(user);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.SelectByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,OriginalEMail,CurrentEMail,Created,Confirmed,LastUpdated,LastLogin,Active,OriginalPwd,CurrentPwd,FailedAttempts,DefaultCurrencyID,OriginalCountryID,LastLoginCountryID,LastFailedCountryID,AuthUserID")] User user)
        {
            if (ModelState.IsValid)
            {
                //Entities dbe = new Entities();
                //dbe.Entry(user).
                db.Update(user);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.SelectByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.SelectByID(id);
            db.Delete(user.UserID);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
