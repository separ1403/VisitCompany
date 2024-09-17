namespace CompanyManagement.Application.Contract.Company
{
    public class CompanySearchModel
    {
        public string Name { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public long LicenceId { get; set; }
        public long AccountId { get; set; } // Add AccountId to the search model
    }
}