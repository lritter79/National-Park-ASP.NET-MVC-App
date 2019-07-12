using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO: ISurveyDAO
    {
        private string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

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

        public IList<SurveyResult> SurveyResults()
        {
            IList<SurveyResult> surveys = new List<SurveyResult>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT parkName, park.parkCode, surveyId, park.state, emailAddress from survey_result INNER JOIN park ON survey_result.parkCode=park.parkCode;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        surveys.Add(MapRowToSurveyResult(reader));
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