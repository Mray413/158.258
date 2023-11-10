using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A2.Models
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Suggestion Giver")]
        public string Name { get; set; }
        [Display(Name = "Suggestion Content")]
        public string Description { get; set; }
        [Display(Name = "Type")]
        public int? FeedBackCategoryID { get; set; }
   
        public virtual FeedbackCategory FeedbackCategory { get; set; }
    }
}