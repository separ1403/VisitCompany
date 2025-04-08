using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class PersonRepository : RepositoryBase<long, Person>, IPersonRepository
    {

        private readonly CompanyContext _companyContext;

        public PersonRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }

        public List<PersonViewModel> SerachTotal(PersonSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            // بارگذاری اطلاعات از پایگاه داده
            var query = _companyContext.Persons
                .Include(x => x.Checklist)
                .ThenInclude(c => c.Accounts)
                 .Include(x => x.Company)

                 .Select(x => new PersonViewModel
                 {
                     Id = x.Id,
                     CompanyBrandChecklist = x.Checklist.Company.CompanyName,
                     CompanyBrand = x.Company.Brand,
                     NamePeopleCo = x.NamePeopleCo,
                     PhonePeopleCo = x.PhonePeopleCo,
                     RspponsePeopleCo = x.RspponsePeopleCo,
                     CompanyId = x.CompanyId ?? 0,
                     CompanyIdChecklist = x.Checklist.CompanyId ?? 0,
                     CreattionDate = x.CreationDate.ToFarsi(), // تغییر فرمت تاریخ به رشته ساده
                   
                    
                     Accounts = x.Checklist.Accounts.Select(a => new AccountViewModel
                     {
                         Id = a.Id,
                         Fullname = a.Fullname,
                         StateCategoryId = a.StateCategoryId
                     }).ToList(),
                 });
            
            if (provincialAdminStateCategoryId.HasValue)
            {
                query = query.Where(x => x.Accounts.Any(a => a.StateCategoryId == provincialAdminStateCategoryId.Value));
            }


            //اعمال فیلترهای جستجو
            if (!string.IsNullOrWhiteSpace(searchModel.NamePeopleCo))
            {
                query = query.Where(x => x.NamePeopleCo.Contains(searchModel.NamePeopleCo));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.PhonePeopleCo))
            {
                query = query.Where(x => x.PhonePeopleCo.Contains(searchModel.PhonePeopleCo));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.RspponsePeopleCo))
            {
                query = query.Where(x => x.RspponsePeopleCo.Contains(searchModel.RspponsePeopleCo));
            }

            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                query = query.Where(x => x.CompanyId == searchModel.CompanyId.Value || x.CompanyIdChecklist == searchModel.CompanyId.Value);
            }

            return query.ToList();
        }
    }
}
