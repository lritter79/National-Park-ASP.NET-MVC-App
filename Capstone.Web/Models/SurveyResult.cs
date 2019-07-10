using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        public int SurveyId { get; set; }
        public int ParkCode { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Display(Name = "Activity Level")]
        [Required(ErrorMessage = "Activity level is required")]
        public string ActivityLevel { get; set; }
    }
}
