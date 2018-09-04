using FluentMigrator;

namespace EmploymentManagement.Migrations
{
    [Migration(201809041550)]
    public class CreateEmploymentManagementDatabase : Migration
    {
        private const string EmployeesTable = "Employees";
        private const string PensionProvidersTable = "PensionProviders";
        private const string EmployeePensionsTable = "EmployeePensions";
        private const string JobPositionsTable = "JobPositions";

        public override void Up()
        {
            Create.Table(EmployeesTable)
                .WithColumn("EmployeeId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("LastName").AsString(100).NotNullable()
                .WithColumn("DateOfBirth").AsDate().NotNullable()
                .WithColumn("Salary").AsDecimal(19,4).Nullable()
                .WithColumn("JobPositionId").AsInt32().Nullable();

            Create.Table(PensionProvidersTable)
                .WithColumn("PensionProviderId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProviderName").AsString(250).NotNullable()
                .WithColumn("IsDefault").AsBoolean().Nullable();

            Create.Table(EmployeePensionsTable)
                .WithColumn("EmployeePensionId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("EmployeeId").AsInt32().NotNullable()
                .WithColumn("TotalContribution").AsDecimal(19,4).NotNullable().WithDefaultValue(0.0)
                .WithColumn("PensionProviderId").AsInt32().NotNullable()
                .WithColumn("LastContributionDate").AsDateTime2().Nullable();

            Create.Table(JobPositionsTable)
                .WithColumn("JobPositionId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("JobPosition").AsString(250).NotNullable();

            this.CreateForeignKey(EmployeePensionsTable, EmployeesTable, "EmployeeId");
            this.CreateForeignKey(EmployeePensionsTable, PensionProvidersTable, "PensionProviderId");
            this.CreateForeignKey(EmployeesTable, JobPositionsTable, "JobPositionId");

            Execute.EmbeddedScript("CreateSPAddContributionToEmployeePensionFunds.sql");
            Execute.EmbeddedScript("CreateViewEmployeesWithFinancialInfo.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("DeleteViewEmployeesWithFinancialInfo.sql");
            Execute.EmbeddedScript("DeleteSPAddContributionToEmployeePensionFunds.sql");

            this.DeleteForeignKey(EmployeePensionsTable, EmployeesTable, "EmployeeId");
            this.DeleteForeignKey(EmployeePensionsTable, PensionProvidersTable, "PensionProviderId");
            this.DeleteForeignKey(EmployeesTable, JobPositionsTable, "JobPositionId");

            Delete.Table(JobPositionsTable);
            Delete.Table(EmployeePensionsTable);
            Delete.Table(PensionProvidersTable);
            Delete.Table(EmployeesTable);          
        }
    }
}
