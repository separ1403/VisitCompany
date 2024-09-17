using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.CompanyAgg;

public class CompanyAccount
{
    public long CompanyId { get; set; }
    public Company Company { get; set; }
    public long AccountId { get; set; }
    public Account Account { get; set; }
}