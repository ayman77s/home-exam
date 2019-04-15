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
    public class product_tableController : Controller
    {
        private home_examEntities db = new home_examEntities();

        // GET: product_table
        public ActionResult Index()
        {
            var product_table = db.product_table.Include(p => p.buyertable);
            return View(product_table.ToList());
        }

        // GET: product_table/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_table product_table = db.product_table.Find(id);
            if (product_table == null)
            {
                return HttpNotFound();
            }
            return View(product_table);
        }

        // GET: product_table/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.buyertables, "product_sold_id", "buyer_name");
            return View();
           
        }

        // POST: product_table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,product_name,product_Quantity,product_id")] product_table product_table)
        {
            if (ModelState.IsValid)
            {
                db.product_table.Add(product_table);
                db.SaveChanges();
                return View();
            }

            ViewBag.product_id = new SelectList(db.buyertables, "product_sold_id", "buyer_name", product_table.product_id);
            return View(product_table);
        }

        // GET: product_table/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_table product_table = db.product_table.Find(id);
            if (product_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.buyertables, "product_sold_id", "buyer_name", product_table.product_id);
            return View(product_table);
        }

        // POST: product_table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,product_name,product_Quantity,product_id")] product_table product_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.buyertables, "product_sold_id", "buyer_name", product_table.product_id);
            return View(product_table);
        }

        // GET: product_table/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_table product_table = db.product_table.Find(id);
            if (product_table == null)
            {
                return HttpNotFound();
            }
            return View(product_table);
        }

        // POST: product_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            product_table product_table = db.product_table.Find(id);
            db.product_table.Remove(product_table);
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
