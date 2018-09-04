using System;

namespace EmploymentManagement.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetFinancialInfoForAllEmployeesFromDatabase();
            IncreaseEmployeesPensionFundBalances();

            Console.ReadLine();
        }

        private static void GetFinancialInfoForAllEmployeesFromDatabase()
        {
            var databaseAccess = new DatabaseAccess();

            Console.WriteLine();
            Console.WriteLine("Financial Information for all Employees");
            Console.WriteLine("------");
            Console.WriteLine("Full Name, Job Position, Salary, Pension Fund Balance");

            foreach (var employee in databaseAccess.GetFinancialInfoForAllEmployees())
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("------");
            Console.WriteLine();
        }

        private static void IncreaseEmployeesPensionFundBalances()
        {
            Console.WriteLine("Do you wish to increase the pension balance of all employees? (Enter 'y' for yes, or any other value for no.)");
            var response = Console.ReadLine();

            if (response != null && response.ToLower().Equals("y"))
            {
                var databaseAccess = new DatabaseAccess();
                databaseAccess.ExecutePensionFundIncrease();
                Console.WriteLine("Done!");
                GetFinancialInfoForAllEmployeesFromDatabase();
            }
            else
            {
                Console.WriteLine("OK! Maybe next time.");
            }            
        }
    }
}
