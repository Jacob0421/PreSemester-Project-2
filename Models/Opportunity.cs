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
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Date Posted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true) ]
        public DateTime datePosted { get; set; }
        
        [Display(Name = "Center Name")]
        public string center { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }
        
        [Required]
        [Display(Name = "Time of Event")]
        public DateTime TimeOfEvent { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

    }
}
