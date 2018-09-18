using System;
using FluentMigrator;

namespace EmploymentManagement.Migrations.Migrations
{
    [Migration(201809181203)]
    public class AddStartDateColumn : Migration
    {
        private const string EmployeesTable = "Employees";
        private const string StartDateColumn = "StartDate";

        public override void Up()
        {
            Alter.Table(EmployeesTable)
                .AddColumn(StartDateColumn)
                .AsDate()
                .SetExistingRowsTo(new DateTime(2010, 1, 1).Date)
                .NotNullable();

            Update.Table(EmployeesTable)
                .Set(new { StartDate = new DateTime(2016, 12, 3).Date })
                .Where(new { EmployeeId = 1 });

            Update.Table(EmployeesTable)
                .Set(new { StartDate = new DateTime(2018, 3, 4).Date })
                .Where(new { EmployeeId = 2 });
        }

        public override void Down()
        {
            Delete.Column(StartDateColumn).FromTable(EmployeesTable);          
        }
    }
}
