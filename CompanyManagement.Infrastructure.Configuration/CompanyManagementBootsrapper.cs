using CompanyManagement.Application;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Infrasructure.EFCore;
using CompanyManagement.Infrasructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Application;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore.Repository;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using CompanyManagement.Domain.LicenceCategoryAgg;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Domain.AccountAgg;

namespace CompanyManagement.Infrastructure.Configuration
{
    public class CompanyManagementBootsrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICompanyApplication, CompanyApplication>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();


            services.AddTransient<ICompanyCategoryRepository, CompanyCategoryRepository>();
            services.AddTransient<ICompanyCategoryApplication, CompanyCategoryApplication>();

            services.AddTransient<ILicenceCategoryRepository, LicenceCategoryRepository>();
            services.AddTransient<ILicenceCategoryApplication, LicenceCategoryApplication>();


            services.AddTransient<IChecklistApplication, ChecklistApplication>();
            services.AddTransient<IChecklistRepository, ChecklistRepository>();

            services.AddTransient<IjuniperhardeningRepository, juniperhardeningRepository>();

            services.AddTransient<IHPEDL380Repository, HPEDL380Repository>();

            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IRoleAplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<IPermissionExposer, CompanyPermissionExposer>();

            services.AddTransient<IWin2019Repository, Win2019Repository>();

            services.AddTransient<IGeneralChecklistRepository, GeneralChecklistRepository>();


            services.AddDbContext<CompanyContext>(x => x.UseSqlServer(connectionString));
        }
       

    }
}
