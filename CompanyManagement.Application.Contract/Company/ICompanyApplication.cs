using CompanyManagement.Application.Contract.LicenceCategory;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CompanyManagement.Application.Contract.Company
{
    public interface ICompanyApplication
    {
        OperationResult Create(CreateCompany command);
        OperationResult Edit(EditCompany command);
        OperationResult BatchEdit(BatchEditCompany command); // متد جدید برای ویرایش دسته‌ای

        EditCompany Getdetails(long id);
        CompanyViewModel Getdetailpartial(long id);


        List<CompanyViewModel> Serach(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null);
        List<CompanyViewModel> SerachTotal(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null);

        List<CompanyViewModel> GetCompenies();
        List<CompanyViewModel> GetCompeniesWithUsername();

        public List<CompanyViewModel> GetCompaniesByCategoryId(int categoryId);
        public List<CompanyViewModel> GetCompaniesByLicenceId(int licenceId);

        //  Company GetCompanyWithCategory(long id); // ??


    }
}
