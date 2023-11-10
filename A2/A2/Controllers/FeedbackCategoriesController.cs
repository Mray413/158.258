using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A2.Data;
using A2.Models;

namespace A2.Controllers
{
    public class FeedbackCategoriesController : Controller
    {
        private A2Context db = new A2Context();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.FeedbackCategories.OrderBy(c => c.Name).ToList());
        }

        // GET: FeedbackCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackCategory feedbackCategory = db.FeedbackCategories.Find(id);
            if (feedbackCategory == null)
            {
                return HttpNotFound();
            }
            return View(feedbackCategory);
        }

        // GET: FeedbackCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackCategories/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] FeedbackCategory feedbackCategory)
        {
            if (ModelState.IsValid)
            {
                db.FeedbackCategories.Add(feedbackCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedbackCategory);
        }

        // GET: FeedbackCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackCategory feedbackCategory = db.FeedbackCategories.Find(id);
            if (feedbackCategory == null)
            {
                return HttpNotFound();
            }
            return View(feedbackCategory);
        }

        // POST: FeedbackCategories/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] FeedbackCategory feedbackCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedbackCategory);
        }

        // GET: FeedbackCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackCategory feedbackCategory = db.FeedbackCategories.Find(id);
            if (feedbackCategory == null)
            {
                return HttpNotFound();
            }
            return View(feedbackCategory);
        }

        // POST: FeedbackCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedbackCategory feedbackCategory = db.FeedbackCategories.Find(id);
            db.FeedbackCategories.Remove(feedbackCategory);
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
        public ActionResult ViewPage0()
        {
            return View();

        }
        public ActionResult ViewPage1()
        {
            return View();

        }
        public ActionResult ViewPage2()
        {
            return View();

        }
    }
}
