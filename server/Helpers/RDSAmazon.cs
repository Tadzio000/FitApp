//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Protocols;
//using WebApi.Entities;

//namespace WebApi.Models
//{
//    public class RDSAmazon
//    {
//        public static string GetRDSConnectionString()
//        {
//            var appConfig = ConfigurationManager.AppSettings;

//            string dbname = "db";

//            if (string.IsNullOrEmpty(dbname)) return null;

//            string username = "db.clbfkbqft4wd.eu - west - 1.rds.amazonaws.com";
//            string password = "postgres";
//            string hostname = "postgres";
//            string port = "5432";

//            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
//        }
//    }
//}
