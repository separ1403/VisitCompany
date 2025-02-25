using System.Security.Claims;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages.Company
{
    public class AddPeopleCompanyModel : PageModel
    {
        [TempData] public string ErrorMessageame { get; set; }

        [TempData] public string SuccessMessageame { get; set; }

        public SelectList Companies;
        public CreatePeopleCompany Command { get; set; }


        private readonly ICompanyApplication _company;
        private readonly IPersonApplication _personApplication;

        public AddPeopleCompanyModel(ICompanyApplication company, IPersonApplication personApplication)
        {
            _company = company;
            _personApplication = personApplication;
        }

        public void OnGet()
        {
            PopulateSelectLists(); // مقداردهی مجدد SelectList ها

        }

        public IActionResult OnPostCreate(CreatePeopleCompany command)
        {
            if (!ModelState.IsValid)
            {
                ErrorMessageame = "لطفا مقادیر خواسته شده را به درستی پر نمایید";
                PopulateSelectLists(); // مقداردهی مجدد SelectList ها
                return Page();
            }

            if (string.IsNullOrWhiteSpace(command.NamePeopleCo) || string.IsNullOrWhiteSpace(command.RspponsePeopleCo) || (command.CompanyId == null))
            {
                ErrorMessageame = "نام شرکت، مسئولیت و نام فرد نباید خالی باشد";
                PopulateSelectLists(); // مقداردهی مجدد SelectList ها
                return Page();
            }

            var operationResult = _personApplication.Create(command);


            if (operationResult.IsSucceeded)
            {
                SuccessMessageame = operationResult.Message;
                return RedirectToPage("./PeopleCompany");
            }
            else
            {
                ErrorMessageame = operationResult.Message;
            }

            PopulateSelectLists(); // مقداردهی مجدد SelectList ها
            return Page();

        }

        private void PopulateSelectLists()
        {
            Companies = new SelectList(_company.GetCompenies(), "Id", "Brand");


        }
    }
    }
