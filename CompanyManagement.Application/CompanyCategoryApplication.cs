using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Domain.CompanyCategoryAgg;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application
{
    public class CompanyCategoryApplication : ICompanyCategoryApplication
    {
        private readonly ICompanyCategoryRepository _companycategoryRepository;

        public CompanyCategoryApplication(ICompanyCategoryRepository companycategoryRepository)
        {
            _companycategoryRepository = companycategoryRepository;
        }

        public OperationResult Create(CreateCompanyCategory command)
        {
            var operation = new OperationResult();
            if (_companycategoryRepository.Exists(x => x.Name == command.Name))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }

            var companyCategory = new CompanyCategory(command.Name, command.Description);
           
            _companycategoryRepository.Create(companyCategory);
            _companycategoryRepository.SaveChanges();

            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public OperationResult Edit(EditCompanyCategory command)
        {
            var operation = new OperationResult();

            var companyCategory = _companycategoryRepository.Get(command.Id);

            if (companyCategory == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }


            if (_companycategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }


            companyCategory.Edit(command.Name, command.Description);

            _companycategoryRepository.SaveChanges();

            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public List<CompanyCategoryViewModel> GetCompanyCategories()
        {
            return _companycategoryRepository.GetCompanyCategories();
        }

        public EditCompanyCategory GetDetails(long id)
        {
            return _companycategoryRepository.GetDetails(id);
        }

        public List<CompanyCategoryViewModel> Search(CompanyCategorySearchModel searchModel)
        {
            return _companycategoryRepository.Search(searchModel);
        }
    }
}
