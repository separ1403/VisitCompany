using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Domain.CompanyCategoryAgg;
using Framework.Infrastructure;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class CompanyCategoryRepository : RepositoryBase<long, CompanyCategory>, ICompanyCategoryRepository
    {
        public CompanyCategoryRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }



        private readonly CompanyContext _companyContext;



        public List<CompanyCategoryViewModel> GetCompanyCategories()
        {
            return _companyContext.CompanyCategories.Select(x => new CompanyCategoryViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                

            }).ToList();
        }

        public EditCompanyCategory GetDetails(long id)
        {
            return _companyContext.CompanyCategories.Select(x => new EditCompanyCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }
            ).FirstOrDefault(x => x.Id == id);
        }

       

        public List<CompanyCategoryViewModel> Search(CompanyCategorySearchModel searchModel)
        {

            var query = _companyContext.CompanyCategories.Select(x => new CompanyCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Count = _companyContext.Companies.Count(c => c.CategoryId == x.Id).ToString() // تعداد شرکت‌ها در هر دسته‌بندی


            });

            if (searchModel != null && !string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
