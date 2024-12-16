using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
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
                 .Select(x => new PersonViewModel
                 {
                     Id = x.Id,
                     CompanyName = x.Checklist.Company.CompanyName,
                     CompanyBrand = x.Checklist.Company.Brand,
                     NamePeopleCo = x.NamePeopleCo,
                     PhonePeopleCo = x.PhonePeopleCo,
                     RspponsePeopleCo = x.RspponsePeopleCo,
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


            // اعمال فیلترهای جستجو
            query = query.Where(c =>
                        (searchModel.NamePeopleCo != null && c.NamePeopleCo.Contains(searchModel.NamePeopleCo)) ||
                        (searchModel.PhonePeopleCo != null && c.PhonePeopleCo.Contains(searchModel.PhonePeopleCo)) ||
                        (searchModel.RspponsePeopleCo != null && c.RspponsePeopleCo.Contains(searchModel.RspponsePeopleCo)) 
                    );
            return query.ToList();
        }
    }
}
