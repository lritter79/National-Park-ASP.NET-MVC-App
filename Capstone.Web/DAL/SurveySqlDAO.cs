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
                ParkName = Convert.ToString(reader["name"]),
                SurveyId = Convert.ToInt32(reader["sureveyId"]),
                ParkCode = Convert.ToInt32(reader["parkCode"]),
                EmailAddress = Convert.ToString(reader["emailAddress"]),
                State = Convert.ToString(reader["state"])
            };
        }

        public IList<SurveyResult> SurveyResults()
        {
            IList<SurveyResult> surveys = new List<SurveyResult>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT name, surveyId, parkCode, emailAddress, state from survey_result INNER JOIN parks ON survey_result.parkCode=parks.parkCode;", conn);

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