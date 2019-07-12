using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        // TODO make select item value pairs for park name and park ID
        [Display(Name = "Park Name")]
        [Required(ErrorMessage = "Park name is required")]
        public string ParkName { get; set; }
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }
        
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

        public Dictionary<string, string> ParkCodekeyValuePairs = new Dictionary<string, string>();
      
        public string GetParkCode()
        {
            return ParkCodekeyValuePairs[ParkName];
        }
        public static List<SelectListItem> Levels = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Inactive" },
            new SelectListItem() { Text = "Sedentary" },
            new SelectListItem() { Text = "Active" },
            new SelectListItem() { Text = "Extremely Active" }
        };

        public List<SelectListItem> ParksMenu = new List<SelectListItem>();

        public static List<SelectListItem> StatesList = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Alabama"},
                new SelectListItem() { Text="Alaska"},
                new SelectListItem() { Text="Arizona"},
                new SelectListItem() { Text="Arkansas"},
                new SelectListItem() { Text="California"},
                new SelectListItem() { Text="Colorado"},
                new SelectListItem() { Text="Connecticut"},
                new SelectListItem() { Text="District of Columbia"},
                new SelectListItem() { Text="Delaware"},
                new SelectListItem() { Text="Florida"},
                new SelectListItem() { Text="Georgia"},
                new SelectListItem() { Text="Hawaii"},
                new SelectListItem() { Text="Idaho"},
                new SelectListItem() { Text="Illinois"},
                new SelectListItem() { Text="Indiana"},
                new SelectListItem() { Text="Iowa"},
                new SelectListItem() { Text="Kansas"},
                new SelectListItem() { Text="Kentucky"},
                new SelectListItem() { Text="Louisiana"},
                new SelectListItem() { Text="Maine"},
                new SelectListItem() { Text="Maryland"},
                new SelectListItem() { Text="Massachusetts"},
                new SelectListItem() { Text="Michigan"},
                new SelectListItem() { Text="Minnesota"},
                new SelectListItem() { Text="Mississippi"},
                new SelectListItem() { Text="Missouri"},
                new SelectListItem() { Text="Montana"},
                new SelectListItem() { Text="Nebraska"},
                new SelectListItem() { Text="Nevada"},
                new SelectListItem() { Text="New Hampshire"},
                new SelectListItem() { Text="New Jersey"},
                new SelectListItem() { Text="New Mexico"},
                new SelectListItem() { Text="New York"},
                new SelectListItem() { Text="North Carolina"},
                new SelectListItem() { Text="North Dakota"},
                new SelectListItem() { Text="Ohio"},
                new SelectListItem() { Text="Oklahoma"},
                new SelectListItem() { Text="Oregon"},
                new SelectListItem() { Text="Pennsylvania"},
                new SelectListItem() { Text="Rhode Island"},
                new SelectListItem() { Text="South Carolina"},
                new SelectListItem() { Text="South Dakota"},
                new SelectListItem() { Text="Tennessee"},
                new SelectListItem() { Text="Texas"},
                new SelectListItem() { Text="Utah"},
                new SelectListItem() { Text="Vermont"},
                new SelectListItem() { Text="Virginia"},
                new SelectListItem() { Text="Washington"},
                new SelectListItem() { Text="West Virginia"},
                new SelectListItem() { Text="Wisconsin"},
                new SelectListItem() { Text="Wyoming"}
            };

    }
}
