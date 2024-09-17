using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application
{
    public class LicenceCategoryApplication : ILicenceCategoryApplication
    {
        private readonly ILicenceCategoryRepository _licencecategoryRepository;

        public LicenceCategoryApplication(ILicenceCategoryRepository licenceCategoryRepository)
        {
            _licencecategoryRepository = licenceCategoryRepository;
        }

        public OperationResult Create(CreateLicenceCategory command)
        {
            var operation = new OperationResult();
            if (_licencecategoryRepository.Exists(x => x.Name == command.Name))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }

            var licenceCategory = new LicenceCategory(command.Name, command.Description);

            _licencecategoryRepository.Create(licenceCategory);
            _licencecategoryRepository.SaveChanges();

            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public OperationResult Edit(EditLicenceCategory command)
        {
            var operation = new OperationResult();

            var licenceCategory = _licencecategoryRepository.Get(command.Id);

            if (licenceCategory == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }


            if (_licencecategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }


            licenceCategory.Edit(command.Name, command.Description);

            _licencecategoryRepository.SaveChanges();

            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public List<LicenceCategoryViewModel> GetLicenceCategories()
        {
            return _licencecategoryRepository.GetLicenceCategories();
        }

        public EditLicenceCategory GetDetails(long id)
        {
            return _licencecategoryRepository.GetDetails(id);
        }

        public List<LicenceCategoryViewModel> Search(LicenceCategorySearchModel searchModel)
        {
            return _licencecategoryRepository.Search(searchModel);
        }
    }
}
