using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC4_CSHARP
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("1984-11-16"), DOJ = DateTime.Parse("2011-08-06"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("1994-08-20"), DOJ = DateTime.Parse("2012-07-07"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("1987-11-11"), DOJ = DateTime.Parse("2015-04-12"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1990-03-06"), DOJ = DateTime.Parse("2016-02-02"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1991-08-03"), DOJ = DateTime.Parse("2016-02-02"), City = "Mumbai" }
            };


            Console.WriteLine("Display Employees:");
            foreach (var emp in empList)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title}  DOB: {emp.DOB.ToString()} DOJ: {emp.DOJ.ToString()} City: {emp.City}");
            }

            Console.WriteLine("************************************************");

            Console.WriteLine("Employees not in Mumbai:");
            var notMumbai = empList.Where(e => e.City != "Mumbai");
            foreach (var emp in notMumbai)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title}  DOB: {emp.DOB.ToString()} DOJ: {emp.DOJ.ToString()} City: {emp.City}");
            }

            Console.WriteLine("************************************************");
            Console.WriteLine("Employees with Title 'AsstManager':");
            var astmng = empList.Where(e => e.Title == "AsstManager");

            foreach (var emp in astmng)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title}  DOB: {emp.DOB.ToString()} DOJ: {emp.DOJ.ToString()} City: {emp.City}");
            }
            Console.WriteLine("************************************************");
            Console.WriteLine("Employees whose Last Name starts with 'S':");

            var lasts = empList.Where(e => e.LastName.StartsWith("S"));
            foreach (var emp in lasts)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title}  DOB: {emp.DOB.ToString()} DOJ: {emp.DOJ.ToString()} City: {emp.City}");
            }
            Console.Read();
        }

     
    }
}




