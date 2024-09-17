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
        EditCompany Getdetails(long id);
      
        List<CompanyViewModel> Serach(CompanySearchModel searchModel);
        List<CompanyViewModel> GetCompenies();
        List<CompanyViewModel> GetCompeniesWithUsername();


        //  Company GetCompanyWithCategory(long id); // ??


    }
}
