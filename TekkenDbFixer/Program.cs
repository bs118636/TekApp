using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenApp.Models;

namespace TekkenDbFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            CleanData();




            Console.ReadLine();
        }

        public static void CleanData()
        {
            using (var db = new TekkenEntity(SqliteConnectionString.ConnectionString))
            {
                try
                {
                    string dropQuery = "DROP TABLE IF EXISTS NewMoveList;";
                    db.Database.ExecuteSqlCommand(dropQuery);

                    for (int i=0; i<1; i++)
                    {

                    }




                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
