using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class NationalParkSqlDAO:INationalParkDAO
    {
        private string connectionString;

        public NationalParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// returns a line from from SQL as a NationalPark object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private NationalPark MapRowToNationalPark(SqlDataReader reader)
        {
            return new NationalPark()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
        }

        public NationalPark GetParkByID(string parkId)
        {
            return GetAllParks().FirstOrDefault(p => p.ParkCode == parkId);
        }

        public NationalPark GetParkByCode(string parkCode)
        {
            return GetAllParks().FirstOrDefault(p => p.ParkCode == parkCode);
        }

        /// <summary>
        /// returns all national parks
        /// </summary>
        /// <returns></returns>
        public IList<NationalPark> GetAllParks()
        {
            IList<NationalPark> nationalParks = new List<NationalPark>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * from park ORDER BY parkName;", conn);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            nationalParks.Add(MapRowToNationalPark(reader));
                        }    
                }

            }
            catch (SqlException)
            {
                throw;
            }

            return nationalParks;
        }
    }
}
