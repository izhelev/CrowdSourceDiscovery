using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSourceDiscovery.EntityFramework.DataLayer;
using CrowdSourceDiscovery.EntityFramework.DataLayer.Migrations;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CSDiscoveryContext, Configuration>());
            TestDB();
        }

        private static void TestDB()
        {

            using (var data = new CSDiscoveryContext())
            {
                var comments = data.Comments.ToList();
                
                foreach (var comment in comments)
                {
                    Console.Write(comment.Text);
                }
            }
        }
    }
}
