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
using A2.ViewModels;

namespace A2.Controllers
{
    public class FeedbacksController : Controller
    {
        private A2Context db = new A2Context();

        // GET: Products
        public ActionResult Index(string category, string search)
        {
            //instantiate a new view model
            FeedbackIndexViewModel viewModel = new FeedbackIndexViewModel();
            var products = db.Feedbacks.Include(p => p.FeedbackCategory);
            //find the products where either the product name field contains search,the product 
            //description contains search, or the product's category name contains search
            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search) ||
                p.Description.Contains(search) ||
                p.FeedbackCategory.Name.Contains(search));
                // ViewBag.Search = search;
                viewModel.Search = search;
            }
            //group search results into categories and count how many items in each category
            viewModel.CatsWithCount = from matchingProducts in products
                                      where
                                      matchingProducts.FeedBackCategoryID != null
                                      group matchingProducts by
                                      matchingProducts.FeedbackCategory.Name into
                                      catGroup
                                      select new CategoryWithCount()
                                      {
                                          CategoryName = catGroup.Key,
                                          ProductCount = catGroup.Count()
                                      };
            //var categories = products.OrderBy(p => p.Category.Name).Select(p => p.FeedbackCategory.Name).Distinct();
            if (!String.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.FeedbackCategory.Name == category);
            }
            //ViewBag.Category = new SelectList(categories); 
            viewModel.Feedbacks = products;
            // return View(products.ToList());
            return View(viewModel);
        }

        // GET: Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.FeedBackCategoryID = new SelectList(db.FeedbackCategories, "ID", "Name");
            return View();
        }

        // POST: Feedbacks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,FeedBackCategoryID")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FeedBackCategoryID = new SelectList(db.FeedbackCategories, "ID", "Name", feedback.FeedBackCategoryID);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeedBackCategoryID = new SelectList(db.FeedbackCategories, "ID", "Name", feedback.FeedBackCategoryID);
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,FeedBackCategoryID")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FeedBackCategoryID = new SelectList(db.FeedbackCategories, "ID", "Name", feedback.FeedBackCategoryID);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
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
