using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Domain.StatesCategoryAgg;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application
{


    public class StateCategoryApplication : IStatecategoryApplication
    {
        private readonly IStateCategoryRepository _statecategoryRepository;

        public StateCategoryApplication(IStateCategoryRepository statecategoryRepository)
        {
            _statecategoryRepository = statecategoryRepository;
        }

        public OperationResult Create(CreateStateCategory command)
        {
            var operation = new OperationResult();
            if (_statecategoryRepository.Exists(x => x.Name == command.Name))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }

            var stateCategory = new StateCategory(command.Name);

            _statecategoryRepository.Create(stateCategory);
            _statecategoryRepository.SaveChanges();

            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public OperationResult Edit(EditStateCategory command)
        {
            var operation = new OperationResult();

            var companyCategory = _statecategoryRepository.Get(command.Id);

            if (companyCategory == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }


            if (_statecategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }


            companyCategory.Edit(command.Name);

            _statecategoryRepository.SaveChanges();

            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public List<StateCategoryViewModel> GetStateCategories()
        {
            return _statecategoryRepository.GetStateCategories();
        }

        public EditStateCategory GetDetails(long id)
        {
            return _statecategoryRepository.GetDetails(id);
        }

        public List<StateCategoryViewModel> Search(StatecategorySearchModel searchModel)
        {
            return _statecategoryRepository.Search(searchModel);
        }

        public List<StateCategoryViewModel> List(long? provincialAdminStateCategoryId = null)

        {
            return _statecategoryRepository.List(provincialAdminStateCategoryId);
        }
    }
}
