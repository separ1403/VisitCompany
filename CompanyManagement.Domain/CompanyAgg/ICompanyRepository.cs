using CompanyManagement.Application.Contract.Company;
using Framework.Domain;

namespace CompanyManagement.Domain.CompanyAgg
{
    public  interface ICompanyRepository :IRepository<long ,Company >
    {
        EditCompany Getdetails(long id);
        CompanyViewModel GetdetailPartialview(long id);


        List<CompanyViewModel> Serach(CompanySearchModel searchModel);

        List<CompanyViewModel> GetCompenies();
        List<CompanyViewModel> GetCompeniesWithUsername();
        Company GetCompanyWithCategory(long id);

       



    }
}
