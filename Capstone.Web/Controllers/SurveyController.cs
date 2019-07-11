using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAO surveyDAO { get; }

        public SurveyController(ISurveyDAO surveyDAO)
        {
            this.surveyDAO = surveyDAO;
        }

        public IActionResult TakeSurvey()
        {
            return View();
        }

        public IActionResult Results()
        {
            
            IList <SurveyResult> surveys = surveyDAO.SurveyResults();

            return View(surveys);
        }
    }
}