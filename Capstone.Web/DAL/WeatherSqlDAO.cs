using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private string connectionString;

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// takes reader input and returns a weather object with propeties from the database
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Weather MapRowToWeather(SqlDataReader reader)
        {
            return new Weather()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                Day = Convert.ToInt16(reader["fiveDayForecastValue"]),
                LowTemp = Convert.ToInt32(reader["low"]),
                HighTemp = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
        }

        /// <summary>
        /// gets the weather for an individual parks
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IList<Weather> GetFiveDayForecast(string Id)
        {
            IList<Weather> FiveDayForecast = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from weather where parkCode = @parkcode ORDER BY fiveDayForecastValue asc;", conn);
                    cmd.Parameters.AddWithValue("@parkcode", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FiveDayForecast.Add(MapRowToWeather(reader));
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return FiveDayForecast;
        }


    }
}
