using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public class Opportunity
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime datePosted { get; set; }
        
        [Display(Name = "Center Name")]
        public string center { get; set; }
       
        //public List<string> addresses { get; set; }
        [Required]
        public DateTime TimeOfEvent { get; set; }
        [Required]
        public string description { get; set; }

    }
}
