using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace ConsoleApp1
{
    public class Helper
    {
        private static Model.RestaurantEntities s_restaurantEntities;
        public static Model.RestaurantEntities GetContext()
        {
            if(s_restaurantEntities == null)
            {
                s_restaurantEntities = new Model.RestaurantEntities();  
            }
            return s_restaurantEntities;
        }

        public void CreateEmployees(Model.Employees employees, Model.EmployeeInformation employeeInformation, Model.Authorization authorization)
        {
            s_restaurantEntities.Employees.Add(employees);
            s_restaurantEntities.EmployeeInformation.Add(employeeInformation);
            //s_restaurantEntities.Posts.Add(posts);
            s_restaurantEntities.Authorization.Add(authorization);
            s_restaurantEntities.SaveChanges();
        }

        public int GetLastIDEmployee()
        {
            int id = s_restaurantEntities.Employees.OrderByDescending(employees => employees.ID).First().ID;
            return id+1;
        }

        public int GetLastIDInfo()
        {
            int id = s_restaurantEntities.EmployeeInformation.OrderByDescending(employeeInformation => employeeInformation.ID).First().ID;
            return id+1;
        }

        public int GetLastIDAuth()
        {
            int id = s_restaurantEntities.Authorization.OrderByDescending(authorization => authorization.ID).First().ID;
            return id + 1;
        }
    }
}
