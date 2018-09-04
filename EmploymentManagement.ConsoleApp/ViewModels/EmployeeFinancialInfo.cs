namespace EmploymentManagement.ConsoleApp.ViewModels
{
    public class EmployeeFinancialInfo
    {
        public string FullName { get; set; }
        public string JobPosition { get; set; }
        public decimal Salary { get; set; }
        public decimal PensionFundBalance { get; set; }

        public override string ToString()
        {
            return $"{FullName}, {JobPosition}, {Salary:C}, {PensionFundBalance:C}";
        }
    }
}
