using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Domain.StatesCategoryAgg;
using Framework.Application;
using Framework.Infrastructure;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{


    public class StatecategoryRepository : RepositoryBase<long, StateCategory>, IStateCategoryRepository
    {
        public StatecategoryRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }



        private readonly CompanyContext _companyContext;



        public List<StateCategoryViewModel> GetStateCategories()
        {
            return _companyContext.CompanyCategories.Select(x => new StateCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,


            }).ToList();
        }

        public List<StateCategoryViewModel> List(long? provincialAdminStateCategoryId = null)
        {
            var query = _companyContext.StateCategories.Select(x => new StateCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,


            });

            // فیلتر محدودیت استان برای ادمین استانی
            if (provincialAdminStateCategoryId.HasValue)
                query = query.Where(x => x.Id == provincialAdminStateCategoryId.Value);

            return query.OrderByDescending(x => x.Id).ToList();
        }


        public EditStateCategory GetDetails(long id)
        {
            return _companyContext.StateCategories.Select(x => new EditStateCategory()
            {
                Id = x.Id,
                Name = x.Name,
            }
            ).FirstOrDefault(x => x.Id == id);
        }



        public List<StateCategoryViewModel> Search(StatecategorySearchModel searchModel)
        {
            var query = _companyContext.StateCategories.Select(x => new StateCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
