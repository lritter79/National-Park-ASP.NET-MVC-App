using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface INationalParkDAO
    {
        NationalPark GetParkByCode(string parkCode);
        IList<NationalPark> GetAllParks();
        Dictionary<NationalPark, int> GetParksByVotes(Dictionary<string, int> results);
    }
}
