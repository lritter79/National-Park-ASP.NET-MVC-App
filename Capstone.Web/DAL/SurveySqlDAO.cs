using System;
using System.Collections.Generic;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Data;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO: ISurveyDAO
    {
        private string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// converts a row from SQL reader to a surveyResult object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private SurveyResult MapRowToSurveyResult(SqlDataReader reader)
        {
            return new SurveyResult()
            {
                ParkName = Convert.ToString(reader["parkName"]),
                SurveyId = Convert.ToInt32(reader["surveyId"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
                EmailAddress = Convert.ToString(reader["emailAddress"]),
                State = Convert.ToString(reader["state"])
            };
        }

        /// <summary>
        /// saves and individual survey result
        /// </summary>
        /// <param name="result"></param>
        public void SaveSurvey(SurveyResult result)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@code, @address, @state, @level);", conn);
                    
                    cmd.Parameters.AddWithValue("@code", result.GetParkCode());
                    cmd.Parameters.AddWithValue("@address", result.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", result.State);
                    cmd.Parameters.AddWithValue("@level", result.ActivityLevel);
                    

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        /// <summary>
        /// gets all rows in the survey results table, still needs a way to return results by count
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> SurveyResults()
        {
            Dictionary<string, int> surveys = new Dictionary<string, int>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT parkName, COUNT(survey_result.parkCode) as votes from survey_result LEFT JOIN park ON survey_result.parkCode = park.parkCode group by parkName order by votes desc;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        surveys.Add(reader.GetString(0), reader.GetInt32(1));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return surveys;
        }

    }
}