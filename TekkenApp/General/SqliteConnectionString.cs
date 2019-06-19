using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenApp.Models;

namespace TekkenApp.General
{
    public static class SqliteConnectionString
    {
        public static string ConnectionString
        {
            get
            {
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string cs = Path.Combine(path, "Tekkendb.db");
                return $"Data Source={cs}; Version=3;";
            }
        }

        //public static object ExecuteQuery(string query)
        //{
        //    var obj = new List<object>();

        //    using (var db = new TekkenEntity(SqliteConnectionString.ConnectionString))
        //    {
        //        obj = db.Database.SqlQuery<object>(query).ToList();
        //    }

        //    return obj;
        //}
    }
}
