using System.Security.Claims;
using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace VisitCompany.Pages.Company
{
    [Authorize]
    public class CreateModel : PageModel
    {


        [TempData]
        public string ErrorMessageame { get; set; }

        [TempData]
        public string SuccessMessageame { get; set; }
        public SelectList States;

       
        public CompanySearchModel searchModel;
        public string companyId;

        public List<SelectListItem> AccountList = new List<SelectListItem>();
        public SelectList CompanyCategories;
        //  public SelectList LicenceCategories;
        public List<SelectListItem> LicenceCategories = new List<SelectListItem>();
        public CompanyResponse CompanyData { get; set; } // تعریف برای ارسال به ویو
        public List<string> Error { get; set; } = new List<string>();
        public CompanyDetailsViewModel CompanyDetails { get; set; }

        private readonly ICompanyCategoryApplication _companyCategoryApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly ILicenceCategoryApplication _licenceApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly IStatecategoryApplication _statecategoryApplication;
        private readonly ILogger<CreateModel> _logger;
        private readonly HttpClient _httpClient;

        public CreateModel(ICompanyCategoryApplication companyCategoryApplication, ICompanyApplication companyApplication, ILicenceCategoryApplication licenceApplication, IAccountApplication accountApplication, IStatecategoryApplication statecategoryApplication, ILogger<CreateModel> logger, HttpClient httpClient)
        {
            _companyCategoryApplication = companyCategoryApplication;
            _companyApplication = companyApplication;
            _licenceApplication = licenceApplication;
            _accountApplication = accountApplication;
            _statecategoryApplication = statecategoryApplication;
            _logger = logger;
            _httpClient = httpClient;
        }

        public CreateCompany Command { get; set; }

        [NeedsPermission(CompanyPermission.CreateCompanies)]
        public void OnGet()
        {

            PopulateSelectLists();
            // برای این است که بعد از اجرای اول مقادیر سلکت لیست ها خالی میشدند
        }


        [NeedsPermission(CompanyPermission.CreateCompanies)]
        public async Task<IActionResult> OnPostCreate(CreateCompany command)
        {

            if (!ModelState.IsValid)
            {
                ErrorMessageame = "لطفا مقادیر خواسته شده را به درستی پر نمایید";
                PopulateSelectLists(); // مقداردهی مجدد SelectList ها
                return Page();
            }

            if (string.IsNullOrWhiteSpace(command.CompanyName) || string.IsNullOrWhiteSpace(command.Brand))
            {
                ErrorMessageame = "نام یا برند شرکت نباید خالی باشد";
                PopulateSelectLists(); // مقداردهی مجدد SelectList ها
                return Page();
            }

            var companyApiCreate = await ApiRasmio(command.NationalCode);
        
            if (companyApiCreate != null)
            {
                command.TitleRasm = companyApiCreate.Title;
                command.CapitalRasm = companyApiCreate.Capital;
                command.AddressRasm = companyApiCreate.Address;
                command.StatusRasm = companyApiCreate.Status;
                command.EdareKolRasm = companyApiCreate.EdareKol;
                command.VahedSabtiRasm = companyApiCreate.VahedSabti;
                command.RegistrationDateRasm = companyApiCreate.RegistrationDate;
                command.RegistrationNoRasm = companyApiCreate.RegistrationNo;
                command.TaxNumberRasm = companyApiCreate.TaxNumber;
                command.PostalCodeRasm = companyApiCreate.PostalCode;  
                command.LastUpdateRasm = companyApiCreate.LastUpdate;
            }


            var operationResult = _companyApplication.Create(command);

            if (operationResult.IsSucceeded)
            {
                SuccessMessageame = operationResult.Message;
                return RedirectToPage("./Create");
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
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);


            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");
            //  LicenceCategories = new SelectList(_licenceApplication.GetLicenceCategories(), "Id", "Name");

            var accounts = _accountApplication.Search(new AccountSearchModel(), currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
            AccountList = accounts.Select(accounts => new SelectListItem(accounts.Fullname, accounts.Id.ToString())).ToList();

            var licence = _licenceApplication.GetLicenceCategories();
            LicenceCategories = licence.Select(licence => new SelectListItem(licence.Name, licence.Id.ToString())).ToList();
            States = new SelectList(_statecategoryApplication.List(currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null), "Id", "Name");

        }

        // کد زیر برای استفاده از ای پی ای مربوط به کمپان یهاس است
        public async Task<CompanyResponse> ApiRasmio(string companyId)
        {
            if (string.IsNullOrEmpty(companyId))
            {
                Error.Add("لطفا شناسه ملی شرکت را وارد کنید");
                return null;
            }

            try
            {
                _httpClient.BaseAddress = new Uri("https://api.rasm.io/api/");
                _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                _httpClient.DefaultRequestHeaders.Add("X-Key", "ccdb6d41-3478-4296-b21d-ac18d0d38319");

                HttpResponseMessage response = await _httpClient.GetAsync($"Company/{companyId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync(); // اجرای ای پی آی , خروجی جی سان
                    var companyData = JsonConvert.DeserializeObject<CompanyResponse>(responseData); // تبدیل ان  

                    // مدیریت داده‌های شرکت
                    Console.WriteLine($"Company Title: {companyData.Title}");
                    Console.WriteLine($"Registration No: {companyData.RegistrationNo}");

                    return companyData;
                }
                else
                {
                    Error.Add($"خطا: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Error.Add("لطفا وضعیت اینترنت خود را بررسی کنید");
                _logger.LogError(ex, "خطا در اتصال به API");
                return null;
            }
            catch (Exception ex)
            {
                Error.Add("یک خطای غیرمنتظره رخ داده است");
                _logger.LogError(ex, "یک خطای غیرمنتظره رخ داده است");
                return null;
            }
        }


    }
}
