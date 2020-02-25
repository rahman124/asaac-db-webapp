using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesAppeals.Models
{
    public class LogAppeal
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; } 
        public string Nationality { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}