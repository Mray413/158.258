using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using A2.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using A2.Data;
using A2.Models;
using System.ComponentModel.DataAnnotations;

namespace A2.ViewModels
{
    public class FeedbackIndexViewModel
    {
        public IQueryable<Feedback> Feedbacks { get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        [Display(Name = "Type")]
        public string Category { get; set; }
        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }
    }
    public class CategoryWithCount
    {
        public int ProductCount { get; set; }
        public string CategoryName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return CategoryName + " (" + ProductCount.ToString() + ")";
            }
        }
    }

}