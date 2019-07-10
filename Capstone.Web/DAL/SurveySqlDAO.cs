using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO
    {
        private string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private SurveyResult MapRowToSurvey(SqlDataReader reader)
        {
            return new SurveyResult()
            {
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
                    SqlCommand cmd = new SqlCommand("SELECT * from survey_result;", conn);

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