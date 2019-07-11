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
            survey.ParksMenu = new List<SelectListItem>();
            foreach(NationalPark park in allParks)
            {
                survey.ParksMenu.Add(new SelectListItem(park.ParkName, park.ParkCode));
            }
            return View(survey);
        }

        public IActionResult Results()
        {
            
            IList <SurveyResult> surveys = surveyDAO.SurveyResults();

            return View(surveys);
        }
    }
}