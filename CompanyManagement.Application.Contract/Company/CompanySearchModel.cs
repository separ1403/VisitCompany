namespace CompanyManagement.Application.Contract.Company
{
    public class CompanySearchModel
    {
        public string Name { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public long LicenceId { get; set; }
        public long LicenceId2 { get; set; }
        public string Refrence { get; set; } = string.Empty;

        public long AccountId { get; set; } // Add AccountId to the search model
        public string Brand { get; set; } = string.Empty;
        public string NationalCode { get;  set; }
        public string ManagerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public long StateCategoryId { get; set; }






    }
}