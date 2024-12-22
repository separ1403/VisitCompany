using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.LicenceCategory;
using Framework.Domain;

namespace CompanyManagement.Domain.CompanyAgg
{
    public  interface ICompanyRepository :IRepository<long ,Company >
    {
        EditCompany Getdetails(long id);
        CompanyViewModel GetdetailPartialview(long id);


        List<CompanyViewModel> Serach(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null);
        List<CompanyViewModel> SerachTotal(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null);

        List<CompanyViewModel> GetCompenies();
        List<CompanyViewModel> GetCompeniesWithUsername();
        public List<CompanyViewModel> GetCompaniesByCategoryId(int categoryId);
        public List<CompanyViewModel> GetCompaniesByLicenceId(int licenceId);






    }
}
