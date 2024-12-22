using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Infrasructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.RoleAgg;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using CompanyManagement.Domain.StatesCategoryAgg;

namespace CompanyManagement.Infrasructure.EFCore
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<GeneralProffesional> GeneralProffesionals { get; set; }
        public DbSet<GeneralPolicy> GeneralPoliies { get; set; }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<StateCategory> StateCategories { get; set; }
        public DbSet<LicenceCategory> LicenceCategories { get; set; }
        public DbSet<HPEDL380> HPEDL380s { get; set; }
        public DbSet<JuniperHardening> JuniperHardenings { get; set; }
        public DbSet<Win2019> Win2019s { get; set; }
        public DbSet<Person> Persons { get; set; }


        public DbSet<GeneralChecklist> GeneralChecklists { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CompanyCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
