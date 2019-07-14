using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using System.Data;

using System.Transactions;

namespace Tests
{
    [TestClass]
    public class DatabaseTest
    {
        protected string ConnectionString = "Server=.\\sqlexpress;Initial Catalog=NPGeek;Trusted_Connection=True";
        private TransactionScope transaction;

        [TestInitialize]
        public void Initialize()
        {
            // limits the scope of tranaction so that the app could be used and tested simultaneously?
            transaction = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //Delete everything from our tables
                //string cmdText = "delete from reservation; delete from site; delete from campground;delete from park; ";
                //SqlCommand command = new SqlCommand(cmdText, connection);
                //command.ExecuteNonQuery();

                ////Add row to park table
                //cmdText = $"INSERT INTO park VALUES('Twin Peaks', 'Washington', '1990-02-26', 2112, 119,'Twin Peaks is an American mystery horror drama television series created by Mark Frost and David Lynch that premiered on April 8, 1990.'); SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //TwinPeaksParkId = Convert.ToInt32(command.ExecuteScalar());

                //cmdText = $"INSERT INTO park VALUES('Jellystone', 'Wyoming', '1990-02-26', 2112, 119,'Watch out for bears stealing picinic baskets.'); SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //JellyStoneParkId = Convert.ToInt32(command.ExecuteScalar());

                //// Add campgrounds to park
                //cmdText = $"INSERT INTO campground VALUES ({TwinPeaksParkId}, 'Black Lodge', 01, 09, 420.00);SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //BlackLodgeCampgroundId = Convert.ToInt32(command.ExecuteScalar());

                //cmdText = $"INSERT INTO campground VALUES ({TwinPeaksParkId}, 'White Lodge', 01, 12, 240.00);SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //WhiteLodgeCampgroundId = Convert.ToInt32(command.ExecuteScalar());

                //cmdText = $"INSERT INTO campground VALUES ({JellyStoneParkId}, 'Grey Lodge', 01, 12, 240.00);SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //GreyLodgeCampgroundId = Convert.ToInt32(command.ExecuteScalar());

                ////Add sites to campgrounds
                //cmdText = $"INSERT INTO site VALUES ({BlackLodgeCampgroundId}, 9, 100, 1, 0, 1);SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //BlackLodgeSiteId = Convert.ToInt32(command.ExecuteScalar());

                //cmdText = $"INSERT INTO site VALUES ({WhiteLodgeCampgroundId}, 9, 10, 1, 1, 0);SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //WhiteLodgeSiteId = Convert.ToInt32(command.ExecuteScalar());

                ////Add resevation to black lodge campsite
                //cmdText = $"INSERT INTO reservation VALUES ({BlackLodgeSiteId}, 'Dale Cooper', '1991-02-26', '1991-04-26','1991-04-27');SELECT SCOPE_IDENTITY();";
                //command = new SqlCommand(cmdText, connection);
                //BlackLodgeReservationId = Convert.ToInt32(command.ExecuteScalar());

            }
        }
        [TestCleanup]
        public void CleanUp()
        {
            // Roll back the transaction
            transaction.Dispose();
        }
    }
}
