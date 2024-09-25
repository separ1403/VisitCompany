using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Framework.Application;
using CompanyManagement.Domain.CompanyAgg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Domain.AccountAgg;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class ChecklistRepository : RepositoryBase<long, Checklist>, IChecklistRepository
    {
        public ChecklistRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }



        private readonly CompanyContext _companyContext;

       



        public EditChecklist Getdetails(long id)
        {
            return _companyContext.Checklists.Select(x => new EditChecklist()
            {
                Id = x.Id,
               // AccountIds = x.AccountId,
                CompanyId = x.CompanyId ?? 0,
                Description = x.Description,
                
                

            }).FirstOrDefault(x => x.Id == id);
        }

    


        private static string MappAccounts(List<Account>? accounts)
        {
            if (accounts == null)
                return string.Empty;

            return string.Join(", ", accounts.Select(x => new AccountDto(x.Id, x.Fullname).FullName));
        }

        public List<ChecklistViewModel> GetChecklists()
        {
            return _companyContext.Checklists
                .Include(x => x.Accounts)
                .Include(x => x.Company)
                .Select(x => new ChecklistViewModel
            {
                Id = x.Id,
              
                Company = x.Company.CompanyName,

                   
                 //   AccountId = x.AccountIds ?? 0,
                    CompanyId = x.CompanyId ?? 0,
                   
                

            }).ToList();
        }

     

        public Checklist GetChecklistWithCompany(long id)
        {
            return _companyContext.Checklists.Include(x => x.Company).FirstOrDefault(x => x.Id == id);
        }

        public Checklist GetChecklistWithAccount(long id)
        {
            return _companyContext.Checklists.Include(x => x.Accounts).FirstOrDefault(x => x.Id == id);
        }

        //public long GetLastCompanyId()
        //{
        //    return _companyContext.Checklists.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0;
        //}

        public DateTime GetLastCompanyDate()
        {
            return _companyContext.Checklists.OrderByDescending(x => x.Id).Select(x => x.CreationDate)
                          .FirstOrDefault();
        }

       

        public List<ChecklistViewModel> GetAverageGeneralByCompany(ChecklistSearchModel searchModel)
        {
            bool conditionExecuted = false;
            // داده‌ها را بازیابی کرده و کوئری را مادی‌سازی کنید
            var checklists = _companyContext.Checklists
                .Include(x => x.Company).Select(x => new ChecklistViewModel
                {
                    AverageGeneral = x.AverageGeneral,
                    Company = x.Company.Brand,
                    CompanyId = x.CompanyId,
                    Id = x.Id,
                    CalDate = x.CreationDate,
                   
                })
                .ToList();

            // اعمال فیلتر
            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                checklists = checklists.Where(x => x.CompanyId == searchModel.CompanyId.Value).ToList();
                conditionExecuted = true;
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate) && !string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var startDate = searchModel.StartDate.ToGeorgianDateTime();
                var endDate = searchModel.EndDate.ToGeorgianDateTime();
                checklists = checklists.Where(x => x.CalDate >= startDate && x.CalDate <= endDate).ToList();
                conditionExecuted = true;
            }

            if (searchModel.TopCompaniesCount.HasValue && searchModel.TopCompaniesCount > 0)
            {
                checklists = checklists.OrderByDescending(x => x.AverageGeneral)
                    .Take(searchModel.TopCompaniesCount.Value).ToList();
                conditionExecuted = true;
            }
            if (!conditionExecuted)
            {
                return null;
            }

            return checklists;
        }


        public List<ChecklistViewModel> GetAverageProffesionalByCompany(ChecklistSearchModel searchModel)
        {
            var checklists = _companyContext.Checklists
                .Include(x => x.Company)
                .Select(x => new ChecklistViewModel
                {
                    //AverageProfessional = x.AverageProfessional,
                    Company = x.Company.Brand,
                    CompanyId = x.CompanyId,
                    Id = x.Id,
                    CalDate = x.CreationDate,
                })
                .ToList();

            // اعمال فیلتر
            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                checklists = checklists.Where(x => x.CompanyId == searchModel.CompanyId.Value).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate) && !string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var startDate = searchModel.StartDate.ToGeorgianDateTime();
                var endDate = searchModel.EndDate.ToGeorgianDateTime();
                checklists = checklists.Where(x => x.CalDate >= startDate && x.CalDate <= endDate).ToList();
            }

            if (searchModel.TopCompaniesCount.HasValue && searchModel.TopCompaniesCount > 0)
            {
                checklists = checklists.OrderByDescending(x => x.AverageProfessional)
                    .Take(searchModel.TopCompaniesCount.Value).ToList();
            }
            else
            {
                checklists = checklists.OrderByDescending(x => x.Id).ToList();
            }

            return checklists;
        }

        public double AverageGeneralcal(EditChecklist command)
        {
            
                var checklist = Get(command.Id);
                
                var hh = checklist.AverageGeneralcal(command);
                return hh;
            
        }

        public List<ChecklistViewModel> SerachByAccount(long accountId)
        {
            var query = _companyContext.Checklists
               .Include(x => x.Company)
               .Include(x => x.Accounts)
               .Include(x => x.JuniperHardening)
               .Include(x => x.JuniperHardening)
               .Select(x => new ChecklistViewModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   NamePeopleCo = x.NamePeopleCo,
                   RspponsePeopleCo = x.RspponsePeopleCo,
                   PhonePeopleCo = x.PhonePeopleCo,
                   CreattionDate =x.CreationDate.ToFarsi(),
                   Company = x.Company.Brand,
                   CompanyId = x.CompanyId,
                   AccountId = x.AccountIds,
                   Accounts = MappAccounts(x.Accounts),
                 
               });

           

            if ( accountId > 0)
            {
                //  query = query.Where(x => x.AccountId.Contains(accountId)); ببینم کدوم دقیق تره
                query = query.Where(x => x.AccountId.Any(id => id == accountId));

            }



            return query.OrderByDescending(x => x.Id).ToList(); throw new NotImplementedException();
        }

    


    public List<ChecklistViewModel> Serach(ChecklistSearchModel searchModel)
        {
            var query = _companyContext.Checklists
              .Include(x => x.Company)
              .Include(x => x.Accounts)
              .Include(x => x.JuniperHardening)
              .Include(x => x.Win2019)
              .Include(x => x.HPEDL380)
              .Select(x => new ChecklistViewModel
              {
                  Id = x.Id,
                  Title = x.Title,
                  NamePeopleCo = x.NamePeopleCo,
                  RspponsePeopleCo = x.RspponsePeopleCo,
                  PhonePeopleCo = x.PhonePeopleCo,
                  CountEmployees = x.CountEmployees,
                  CountFolowers = x.CountFolowers,
                  Company = x.Company.Brand,
                  CompanyId = x.CompanyId,
                  AccountId = x.AccountIds,
                  Accounts = MappAccounts(x.Accounts),
                  AverageGeneral = x.AverageGeneral,
                  AverageHpedl380 = x.HPEDL380.AverageHpedl380,
                  AverageJunipper = x.JuniperHardening.AverageJuniper,
                  AverageWin2019 = x.Win2019.AverageWin2019,

              });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Title.Contains(searchModel.Name));
            }

            if (searchModel.AccountId.HasValue && searchModel.AccountId > 0)
            {
                query = query.Where(x => x.AccountId.Equals(searchModel.AccountId.Value));
            }

            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                query = query.Where(x => x.CompanyId == searchModel.CompanyId.Value);
            }

            return query.OrderByDescending(x => x.Id).ToList(); throw new NotImplementedException();
        }

        public List<ChecklistViewModel> GetAverageGeneralByCompareCompany(ChecklistSearchModel2 searchModel)
        {
            bool conditionExecuted = false;
            // داده‌ها را بازیابی کرده و کوئری را مادی‌سازی کنید
            var checklists = _companyContext.Checklists
                .Include(x => x.Company).Select(x => new ChecklistViewModel
                {
                    AverageGeneral = x.AverageGeneral,
                    Company = x.Company.Brand,
                    CompanyId = x.CompanyId,
                    Id = x.Id,
                    CalDate = x.CreationDate,
                   // AverageProfessional = x.AverageProfessional,
                })
                .ToList();

            // اعمال فیلتر
            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                checklists = checklists.Where(x => x.CompanyId == searchModel.CompanyId.Value).ToList();
                conditionExecuted = true;

            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate) && !string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var startDate = searchModel.StartDate.ToGeorgianDateTime();
                var endDate = searchModel.EndDate.ToGeorgianDateTime();
                checklists = checklists.Where(x => x.CalDate >= startDate && x.CalDate <= endDate).ToList();
                conditionExecuted = true;

            }

            if (searchModel.TopCompaniesCount.HasValue && searchModel.TopCompaniesCount > 0)
            {
                checklists = checklists.OrderByDescending(x => x.AverageGeneral)
                    .Take(searchModel.TopCompaniesCount.Value).ToList();
                conditionExecuted = true;
            }


            if (!conditionExecuted)
            {
                return null;
            }



            return checklists;
        }

        //public double AverageProffcal(EditChecklist command)
        //{
        //    var checklist = Get(command.Id);
        //    return checklist.AverageProffcal(command);
        //}
    }
}
