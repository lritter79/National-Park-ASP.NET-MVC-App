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

        public SurveyResult fillLists()
        {
            var allParks = nationalParkDAO.GetAllParks();
            var survey = new SurveyResult();


            foreach (NationalPark park in allParks)
            {
                survey.ParkCodekeyValuePairs.Add(park.ParkName, park.ParkCode);
                survey.ParksMenu.Add(new SelectListItem() { Text = park.ParkName });
            }

            return survey;
        }
        public IActionResult TakeSurvey()
        {
            
            var survey = fillLists();
            
          
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeSurvey(SurveyResult survey)
        {
            if (!ModelState.IsValid)
            {

                survey = fillLists();


                return View(survey);
            }
            else
            {
                survey = fillLists();

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