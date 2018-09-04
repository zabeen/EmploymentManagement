using FluentMigrator;

namespace EmploymentManagement.Migrations
{
    public static class MigrationExtensions
    {
        public static void CreateForeignKey(this Migration migration, string fromTable, string toTable, string columnName)
        {
            migration.Create.ForeignKey(GetForeignKeyName(fromTable, toTable, columnName))
                .FromTable(fromTable).ForeignColumn(columnName)
                .ToTable(toTable).PrimaryColumn(columnName);
        }

        public static void DeleteForeignKey(this Migration migration, string fromTable, string toTable, string columnName)
        {
            migration.Delete.ForeignKey(GetForeignKeyName(fromTable, toTable, columnName))
                .OnTable(fromTable);
        }

        private static string GetForeignKeyName(string fromTable, string toTable, string columnName)
        {
            return $"FK_{fromTable}_{columnName}_{toTable}_{columnName}";
        }
    }
}
