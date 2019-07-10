using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        /// <summary>
        /// The forecast day. Today is day 1, tomorrow is day 2, and so on
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// low temp in F
        /// </summary>
        public int LowTemp { get; set; }
        /// <summary>
        /// high temp in F
        /// </summary>
        public int HighTemp { get; set; }
        public string Forecast { get; set; }

    }
}
