using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAO
    {
        /// <summary>
        /// Get all Survey Resullts
        /// </summary>
        /// <returns></returns>
        IList<SurveyResult> SurveyResults();

        
    }
}
