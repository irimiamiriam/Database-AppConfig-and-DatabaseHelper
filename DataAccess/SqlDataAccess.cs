using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_SqlDataAdapter_Dataset.DataAccess
{
    class SqlDataAccess
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public static string GetCartiPath()
        {
            return ConfigurationManager.AppSettings["Carti"];
        }
    }
}
