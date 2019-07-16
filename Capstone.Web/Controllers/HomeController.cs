using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private INationalParkDAO nationalParkDAO { get; }
        private IWeatherDAO weatherDAO { get; }

        public HomeController(INationalParkDAO nationalParkDAO, IWeatherDAO weatherDAO)
        {
            this.nationalParkDAO = nationalParkDAO;
            this.weatherDAO = weatherDAO;
        }




        public IActionResult Index()
        {
            IList<NationalPark> parks = nationalParkDAO.GetAllParks();

            return View(parks);
        }

      [HttpGet]
      public IActionResult ParkDetail(string id)
        {

            //string tempBoolString = HttpContext.Session.GetString("temp_val");
            //if (tempBoolString == "true")
            //{
            //    ModelState
            //}

            NationalPark park = nationalParkDAO.GetParkByCode(id);
            park.FiveDayForecast = weatherDAO.GetFiveDayForecast(id);
            return View(park);
        }

    //[HttpPost]
    //public IActionResult ToggleTemp(bool isCelsius, string parkCode)
    //    {
    //        string tempBoolString = JsonConvert.ToString(isCelsius);

    //        if (isCelsius)
    //        {
    //            HttpContext.Session.SetString("temp_val", "false");
    //        }
    //        else
    //        {
    //            HttpContext.Session.SetString("temp_val", "true");
    //        }
    //        return RedirectToAction("Detail", new { id = parkCode });
        //}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
