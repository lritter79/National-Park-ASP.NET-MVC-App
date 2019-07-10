using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IWeatherDAO
    {
        /// <summary>
        /// Gets five day forecast for that park
        /// </summary>
        /// <param name="park"></param>
        /// <returns></returns>
        IList<Weather> GetFiveDayForecast(NationalPark park);
    }
}
