using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A2.Models
{
    public class FeedbackCategory
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Type")]
        public string Name { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}