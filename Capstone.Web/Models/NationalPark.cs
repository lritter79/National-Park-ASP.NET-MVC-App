﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Models
{
    public class NationalPark
    {
        
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public IList<NationalPark> AllParks { get; set; }
        public IList<Weather> FiveDayForecast { get; set; }
            

        public double GetTempInCelsius (int inFahrenheit)
        {
            double inCelsius = (inFahrenheit - 32) * 0.55555555556;
            return inCelsius;
        }
        public Dictionary<string, string> ForecastAdvisoryMessagePairs = new Dictionary<string, string>()
        {
            {"snow","ALERT: Pack snowshoes"},
            {"rain","ALERT: Pack rain gear and wear waterproof shoes"},
            {"thunderstorms","ALERT: Seek shelter and avoid hiking on exposed ridges"},
            {"sunny","ALERT: Pack sunblock"},
            {"partly cloudy",""},
            {"cloudy",""}
        };

        
    }


}

//a.This may be on the same page as the park detail or on a separate page.
//b.The forecast for each park can be obtained from the Weather Forecast database table.
//c.If the daily forecast calls for snow, then tell the user to pack snowshoes.
//d.If the daily forecast calls for rain, then tell the user to pack rain gear and wear waterproof shoes.
//e.If the daily forecast calls for thunderstorms, tell the user to seek shelter and avoid hiking on
//exposed ridges.
//f.If the daily forecast calls for sun, tell the user to pack sunblock.
//g.If the temperature is going to exceed 75 degrees, tell the user to bring an extra gallon of water.
//h.If the difference between the high and low temperature exceeds 20 degrees, tell the user to
//wear breathable layers.
//i.If the temperature is going to be below 20 degrees, make sure to warn the user of the dangers
//of exposure to frigid temperatures.

