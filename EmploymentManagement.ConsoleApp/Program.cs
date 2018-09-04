using System;

namespace EmploymentManagement.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetFinancialInfoForAllEmployeesFromDatabase();

            Console.ReadLine();
        }

        private static void GetFinancialInfoForAllEmployeesFromDatabase()
        {
            var databaseAccess = new DatabaseAccess();

            Console.WriteLine("Employees with Financial Information");
            Console.WriteLine("------");
            Console.WriteLine("Full Name, Job Position, Salary, Pension Fund Balance");

            foreach (var employee in databaseAccess.GetFinancialInfoForAllEmployees())
            {
                Console.WriteLine(employee);
            }
        }
    }
}
