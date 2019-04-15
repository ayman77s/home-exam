using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using homeexam.Models;

namespace homeexam.Controllers
{
    public class buyertablesController : Controller
    {
        private home_examEntities db = new home_examEntities();

        // GET: buyertables
        public ActionResult Index()
        {
            return View(db.buyertables.ToList());
        }

        // GET: buyertables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            buyertable buyertable = db.buyertables.Find(id);
            if (buyertable == null)
            {
                return HttpNotFound();
            }
            return View(buyertable);
        }

        // GET: buyertables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: buyertables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,buyer_name,product_sold_id,Quantity")] buyertable buyertable)
        {
            if (ModelState.IsValid)
            {
                db.buyertables.Add(buyertable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buyertable);
        }

        // GET: buyertables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            buyertable buyertable = db.buyertables.Find(id);
            if (buyertable == null)
            {
                return HttpNotFound();
            }
            return View(buyertable);
        }

        // POST: buyertables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,buyer_name,product_sold_id,Quantity")] buyertable buyertable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyertable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyertable);
        }

        // GET: buyertables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            buyertable buyertable = db.buyertables.Find(id);
            if (buyertable == null)
            {
                return HttpNotFound();
            }
            return View(buyertable);
        }

        // POST: buyertables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            buyertable buyertable = db.buyertables.Find(id);
            db.buyertables.Remove(buyertable);
            db.SaveChanges();
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
