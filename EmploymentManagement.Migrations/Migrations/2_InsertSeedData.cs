using FluentMigrator;

namespace EmploymentManagement.Migrations.Migrations
{
    [Migration(201809042212)]
    public class InsertSeedData : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("InsertSeedData.sql");
        }

        public override void Down()
        {
            Delete.FromTable("EmployeePensions").AllRows();
            Delete.FromTable("Employees").AllRows();
            Delete.FromTable("PensionProviders").AllRows();
            Delete.FromTable("JobPositions").AllRows();
        }
    }
}
