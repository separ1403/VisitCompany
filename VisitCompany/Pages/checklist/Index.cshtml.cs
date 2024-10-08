using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IndexModel(IAccountApplication accountApplication, ICompanyApplication company,
            IChecklistApplication checklistApplication)
        {
            _accountApplication = accountApplication;
            _company = company;
            _checklistApplication = checklistApplication;
        }

        public ChecklistSearchModel SearchModel;
        public List<ChecklistViewModel> Checklists;
        public SelectList Companies;
        public SelectList Accounts;


        private readonly IAccountApplication _accountApplication;
        private readonly ICompanyApplication _company;
        private readonly IChecklistApplication _checklistApplication;



        public void OnGet(ChecklistSearchModel searchModel)
        {

            Companies = new SelectList(_company.GetCompenies(), "Id", "Brand");

            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");

            Checklists = _checklistApplication.Serach(searchModel);
            //2 تا مشکل داره یکی نام ارزیاب رو نمایس نمیده تو جستجو
            //یکی هم هنگام جستجو در repository گفتم categoryid contain باشه 
            // ممکنه که عدد 1 در 11 هم باشه تست کنم ببینم چطور میشه
        }

    }
}

