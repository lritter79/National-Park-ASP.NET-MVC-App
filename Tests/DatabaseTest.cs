using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.IO;
using System.Reflection;
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
                string cmdText = "delete from reservation; delete from site; delete from campground;delete from park; ";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.ExecuteNonQuery();

                //Add row to park table
                cmdText = $"INSERT INTO park VALUES('TWPK','Twin Peaks', 'Washington','1990','420','69','42','cancelled','1990','1','Cooper Cooper', 'The Major', 'Under the sycamores', '11','119');";
                command = new SqlCommand(cmdText, connection);

                cmdText = $"INSERT INTO park VALUES('JSNP','Jellystone', 'Wyoming','1990','420','69','42','cancelled','1990','1','Cooper Cooper', 'The Major', 'Under the sycamores', '11','119');";
                command = new SqlCommand(cmdText, connection);
                //JellyStoneParkId = Convert.ToInt32(command.ExecuteScalar());
                cmdText = $"INSERT INTO park VALUES('CCL','Camp Crystal Lake', 'Wyoming','1990','420','69','42','cancelled','1990','1','Cooper Cooper', 'The Major', 'Under the sycamores', '11','119');";
                command = new SqlCommand(cmdText, connection);

                cmdText = $"INSERT INTO park VALUES('LP','Linkin Park', 'Wyoming','1990','420','69','42','cancelled','1990','1','Cooper Cooper', 'The Major', 'Under the sycamores', '11','119');";
                command = new SqlCommand(cmdText, connection);

                //// Add weather to park
                cmdText = "INSERT INTO weather VALUES('JSNP',1,27,40,'snow');INSERT INTO weather VALUES('JSNP',2,31,43,'snow');INSERT INTO weather VALUES('JSNP',3,28,40,'partly cloudy');INSERT INTO weather VALUES('JSNP',4,24,34,'cloudy');INSERT INTO weather VALUES('JSNP',5,25,32,'snow');";
                command = new SqlCommand(cmdText, connection);

                cmdText = "INSERT INTO weather VALUES('TWPK',1,27,40,'snow');INSERT INTO weather VALUES('TWPK',2,31,43,'snow');INSERT INTO weather VALUES('TWPK',3,28,40,'partly cloudy');INSERT INTO weather VALUES('TWPK',4,24,34,'cloudy');INSERT INTO weather VALUES('TWPK',5,25,32,'snow');";
                command = new SqlCommand(cmdText, connection);

                cmdText = "INSERT INTO weather VALUES('CCL',1,27,40,'snow');INSERT INTO weather VALUES('CCL',2,31,43,'snow');INSERT INTO weather VALUES('CCL',3,28,40,'partly cloudy');INSERT INTO weather VALUES('CCL',4,24,34,'cloudy');INSERT INTO weather VALUES('CCL',5,25,32,'snow');";
                command = new SqlCommand(cmdText, connection);

                cmdText = "INSERT INTO weather VALUES('LP',1,27,40,'snow');INSERT INTO weather VALUES('LP',2,31,43,'snow');INSERT INTO weather VALUES('LP',3,28,40,'partly cloudy');INSERT INTO weather VALUES('LP',4,24,34,'cloudy');INSERT INTO weather VALUES('LP',5,25,32,'snow');";
                command = new SqlCommand(cmdText, connection);

                // Add surveys
                cmdText = "INSERT INTO survey_result VALUES('JSNP', 'foo@bar.com', 'x', 'y');INSERT INTO survey_result VALUES('JSNP', 'foo@bar.com', 'x', 'y');INSERT INTO survey_result VALUES('TWPK', 'foo@bar.com', 'x', 'y');";
                command = new SqlCommand(cmdText, connection);

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
