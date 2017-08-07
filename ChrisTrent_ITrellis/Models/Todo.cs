using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChrisTrent_ITrellis.Models
{
    public class Todo
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public int ID  { get; set; }
        
        [Required]
        [Display(Name = "To Do")]
        public string toDo_Item { get; set; }

        [Required]
        [Display(Name = "Deadline Date")]
        public DateTime deadLineDate { get; set; }
        [Required]
        [Display(Name = "Task Completed")]
        public bool isComplete { get; set; }

        [Display(Name = "More Details")]
        public string moreDetails { get; set; }
    }
}