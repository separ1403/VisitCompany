using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.CompanyAgg;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    [Authorize]
    public class CompanyRepository : RepositoryBase<long, Company>, ICompanyRepository
    {
      

        private readonly CompanyContext _companyContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthHelper _authHelper;

        public CompanyRepository(CompanyContext companyContext, IHttpContextAccessor httpContextAccessor, IAuthHelper authHelper) : base(companyContext)
        {
            _companyContext = companyContext;
            _httpContextAccessor = httpContextAccessor;
            _authHelper = authHelper;
        }

        public List<CompanyViewModel> GetCompeniesWithUsername()
        {
            if (_authHelper.IsAuthenticated())
            {
                string idFromSession = _httpContextAccessor.HttpContext.Session.GetString("CommandId"); // inja  az session get karde va khandeh

                if (string.IsNullOrEmpty(idFromSession)) //بسته شدن مرورگر به‌طور پیش‌فرض باعث پاک شدن سشن می‌شود، زیرا سشن‌ها به کوکی‌های موقتی متکی هستند که در هنگام بسته شدن مرورگر از بین می‌روند.
                {
                    // مدیریت وضعیت زمانی که مقدار CommandId در سشن وجود ندارد
                    _httpContextAccessor.HttpContext.Response.Redirect("/Account");
                    return new List<CompanyViewModel>();
                }



                long idAsLong = long.Parse(idFromSession);

                return _companyContext.Companies
                    .Where(company => company.AccountIds.Contains(idAsLong)) // شرط برای بررسی وجود idAsLong در AccountIds
                    .Select(x => new CompanyViewModel()
                    {
                        Id = x.Id,
                        CompanyName = x.CompanyName,
                        Brand = x.Brand

                    }).ToList();
               
            }
            else
            {
                return new List<CompanyViewModel>();
            }


        }

        public Company GetCompanyWithCategory(long id) // benazaram ye company ro be hamrahe name category miare
        {
            return _companyContext.Companies.Include(x => x.CompanyCategory).FirstOrDefault(x => x.Id == id);
        }





        public List<CompanyViewModel> Serach(CompanySearchModel searchModel)
        {
            var companies = _companyContext.Companies
                .Include(c => c.CompanyCategory)
                .Include(c => c.LicenceCategories)
                .Include(c => c.Accounts)
                .ToList();
            
            //foreach (var company in companies)
            //{
            //    // بررسی داده‌های Accounts
            //    Console.WriteLine($"Company: {company.CompanyName}, Accounts Count: {company.Accounts.Count}");

            //    foreach (var account in company.Accounts)
            //    {
            //        Console.WriteLine($"Account Id: {account.Id}");
            //    }
            //}   برای چک کردن مقدار برای اینکه بفهمیم ایا اینکلود ها کار میکندد یا نه

            var query = companies
                .Select(c => new CompanyViewModel
                {
                    Id = c.Id,
                    CompanyName = c.CompanyName,
                    Brand = c.Brand,
                    ManagerName = c.ManagerName,
                    SecurityManagerName = c.SecurityManagerName,
                    PhoneNumber = c.PhoneNumber,
                    Description = c.Description,
                    NationalCode = c.NationalCode,
                    IsActive = c.IsActive,
                    Category = c.CompanyCategory.Name,
                    CategoryId = c.CategoryId,
                    LicenceId = c.LicenceId,
                    CompanyCreateDate = c.CreationDate.ToFarsi(),
                    AccountIds = MapAccounts(c.Accounts),
                    Domain = c.Domain,
                    
                    
                }).ToList();

            //foreach (var company in query)
            //{
            //    Console.WriteLine($"Company: {company.CompanyName}, AccountIds: {string.Join(", ", company.AccountIds)}");
            //}

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(c => c.CompanyName.Contains(searchModel.Name)).ToList();

            if (searchModel.CategoryId > 0)
                query = query.Where(c => c.CategoryId == searchModel.CategoryId).ToList();


            if (searchModel.LicenceId > 0)
                query = query.Where(c => c.LicenceId == searchModel.LicenceId).ToList();

            if (searchModel.AccountId > 0)
            {
                query = query.Where(c => c.AccountIds.Contains(searchModel.AccountId)).ToList();
            }

            return query.OrderByDescending(c => c.Id).ToList();
        }
        private static List<long> MapAccounts(List<Account>? accounts)
        {
            if (accounts == null)
                return new List<long>();

            return accounts.Select(x => x.Id).ToList();
        }

        public List<CompanyViewModel> GetCompenies()
        {
            return _companyContext.Companies.Select(x => new CompanyViewModel()
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                Brand= x.Brand

            }).ToList();


        }

        public EditCompany Getdetails(long id)
        {
            return _companyContext.Companies
                .Where(x => x.Id == id)
                .Select(x => new EditCompany
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    Brand = x.Brand,
                    ManagerName = x.ManagerName,
                    SecurityManagerName = x.SecurityManagerName,
                    PhoneNumber = x.PhoneNumber,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    NationalCode = x.NationalCode,
                   // AccountIds = x.Accounts != null ? x.Accounts.Select(a => a.Id).ToList() : new List<long>()
                    AccountIds = x.AccountIds, // اضافه کردن این خط
                    Doamin = x.Domain,

                })
                .FirstOrDefault();
        }




    }

}
