using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SMS.Models;
namespace SMS.Models
{
    public sealed class UtilFunctions
    {

        public static List<EmployeeMaster> GetEmployees()
        {
            using (var db = new SMSDbContext())
            {
                return db.Employees.ToList();
            }
                 
        }
        public static List<ClientMaster> GetClients()
        {
            using (var db = new SMSDbContext())
            {
                return db.ClientMasters.ToList();
            }

        }
        public static List<CategoryMaster> GetCategories()
        {
            using (var db = new SMSDbContext())
            {
                return db.CategoryMasters.ToList();
            }

        }
        public static List<StatusMaster> GetStatus()
        {
            using (var db = new SMSDbContext())
            {
                return db.StatusMasters.ToList();
            }


        }
       public  static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            var table = new DataTable();

            // Get max columns.
            var columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (var i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (object[] array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

    }
}