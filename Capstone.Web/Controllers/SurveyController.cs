using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAO surveyDAO { get; }
        private INationalParkDAO nationalParkDAO { get; }

        public SurveyController(ISurveyDAO surveyDAO, INationalParkDAO nationalParkDAO)
        {
            this.surveyDAO = surveyDAO;
            this.nationalParkDAO = nationalParkDAO;
        }

        public IActionResult TakeSurvey()
        {
            var allParks = nationalParkDAO.GetAllParks();
            var survey = new SurveyResult();
            
            
            foreach(NationalPark park in allParks)
            {
                SurveyResult.ParkCodekeyValuePairs.Add(park.ParkName, park.ParkCode);
                survey.ParksMenu.Add(new SelectListItem() { Text = park.ParkName });
            }
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeSurvey(SurveyResult survey)
        {
            if (!ModelState.IsValid)
            {
                var allParks = nationalParkDAO.GetAllParks();
               
                

                foreach (NationalPark park in allParks)
                {
                    
                }
                return View(survey);
                
            }
            else
            {

                surveyDAO.SaveSurvey(survey);
                
                return RedirectToAction("Results");
            }
        }

        public IActionResult Results()
        {
            
            IList <SurveyResult> surveys = surveyDAO.SurveyResults();

            return View(surveys);
        }
    }
}