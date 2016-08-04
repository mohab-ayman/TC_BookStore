using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using TC_BookStore.TestInputData;
using Dapper;
using System.IO;

namespace TC_BookStore.TestData
{
     class RegisterationData
    {
        public static string TestDataFileConnection()
        {
            string fileLocation = AppDomain.CurrentDomain.BaseDirectory;/*Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;*/
            var fileName = fileLocation + ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static UserData GetTestData(string TestcaseID)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = "select * from [ResgisterUsers$] where TCID ='" + TestcaseID + "'";
                //string.Format("select * from [ResgisterUsers$] where TCID ='{0}'", Int32.Parse(TestcaseID));
                var value = connection.Query<UserData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}

