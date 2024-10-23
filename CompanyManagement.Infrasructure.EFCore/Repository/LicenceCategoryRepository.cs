using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using Framework.Domain;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class LicenceCategoryRepository : RepositoryBase<long, LicenceCategory>, ILicenceCategoryRepository
    {
        private readonly CompanyContext _companyContext;

        public LicenceCategoryRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;

        }

        public List<LicenceCategoryViewModel> GetLicenceCategories()
        {
            return _companyContext.LicenceCategories.Select(x => new LicenceCategoryViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                

            }).ToList();
        }

        public List<LicenceCategory> GetLicenceByIds(List<long> licenceIds)
        {
            return _companyContext.LicenceCategories.Where(a => licenceIds.Contains(a.Id)).ToList();// account hayee ro az table account mide ke id on ha barabar bashe ba Accountids ha

        }

        public EditLicenceCategory GetDetails(long id)
        {
            return _companyContext.LicenceCategories.Select(x => new EditLicenceCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }
            ).FirstOrDefault(x => x.Id == id);
        }

       

        public List<LicenceCategoryViewModel> Search(LicenceCategorySearchModel searchModel)
        {
            var query = _companyContext.LicenceCategories.Select(x => new LicenceCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }

   
    }
}
