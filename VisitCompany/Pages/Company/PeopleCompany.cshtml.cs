using System.Security.Claims;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages.Company
{
    [Authorize]

    public class PeopleCompanyModel : PageModel
    {
        public PersonSearchModel SearchModel;
        public SelectList Companies;
        public List<CompanyViewModel> Companiess { get; set; }
        public List<PersonViewModel> Persons;

        private readonly IChecklistApplication _checklistApplication;
        private readonly ICompanyApplication _company;
        private readonly IPersonApplication _personApplication;

        public PeopleCompanyModel(IChecklistApplication checklistApplication, ICompanyApplication company, IPersonApplication personApplication)
        {
            _checklistApplication = checklistApplication;
            _company = company;
            _personApplication = personApplication;
        }

        public void OnGet(PersonSearchModel searchModel)
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);


            Persons = _personApplication.SerachTotal(searchModel, currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);

            Companies = new SelectList(_company.GetCompenies(), "Id", "Brand");
              
            // AccountsList = _accountApplication.Search(new AccountSearchModel()); ;
                                       
        }
    }
}
