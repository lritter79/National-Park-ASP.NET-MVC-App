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


        [HttpGet]
        public IActionResult TakeSurvey()
        {
            var allParks = nationalParkDAO.GetAllParks();
            var survey = new SurveyResult();
            survey.fillLists(allParks);
          
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeSurvey(SurveyResult survey)
        {
            if (!ModelState.IsValid)
            {
                var allParks = nationalParkDAO.GetAllParks();
                survey.fillLists(allParks);
                return View(survey);
            }
            else
            {
                var allParks = nationalParkDAO.GetAllParks();
                survey.fillLists(allParks);
                surveyDAO.SaveSurvey(survey);
                return RedirectToAction("Results");
            }
        }

        [HttpGet]
        public IActionResult Results()
        {

            Dictionary<string, int> surveys = surveyDAO.SurveyResults();

            return View(surveys);
        }
    }
}