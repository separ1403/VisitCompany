using CompanyManagement.Application.Contract.Company;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace VisitCompany.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {

        // کد زیر برای استفاده از ای پی ای مربوط به کمپان یهاس است
        public async Task OnGet(string companyId)
        {

            
        }





    }
}
