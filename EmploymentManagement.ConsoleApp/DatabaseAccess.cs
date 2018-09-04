using Dapper;
using EmploymentManagement.ConsoleApp.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmploymentManagement.ConsoleApp
{
    public class DatabaseAccess
    {
        private readonly string connectionString =
            new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                IntegratedSecurity = true,
                InitialCatalog = "EmploymentDb"
            }.ConnectionString;

        public IEnumerable<EmployeeFinancialInfo> GetFinancialInfoForAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<EmployeeFinancialInfo>("SELECT * FROM View_EmployeesWithFinancialInfo");
            }
        }

        public void ExecutePensionFundIncrease()
        {
            const decimal salaryPercentageToContribute = (decimal) 5.0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_AddContributionToEmployeePensionFunds",
                    new { SalaryPercentageToContribute = salaryPercentageToContribute },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}