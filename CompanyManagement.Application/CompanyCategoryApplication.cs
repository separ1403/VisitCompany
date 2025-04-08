using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Domain.CompanyCategoryAgg;
using Framework.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyManagement.Application

{
    public class CompanyCategoryApplication : ICompanyCategoryApplication
    {
        private readonly ICompanyCategoryRepository _companycategoryRepository;
        private readonly ILogger<CompanyCategoryApplication> _logger;

        public CompanyCategoryApplication(ICompanyCategoryRepository companycategoryRepository, ILogger<CompanyCategoryApplication> logger)
        {
            _companycategoryRepository = companycategoryRepository;
            _logger = logger;
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

            try
            {
                _companycategoryRepository.Create(companyCategory);
                _companycategoryRepository.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "خطا در ایجاد شرکت  جدید.");
                return operation.Failed("مشکلی در ذخیره‌سازی داده‌ها وجود دارد.");
            }


                       

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



            try
            {
                _companycategoryRepository.SaveChanges();
                operation.Succeeded(ApplicationMessages.SuccessMessage);


                //_companyRepository.SaveChanges();
            }


            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "خطا در ویرایش .");
                return operation.Failed("مشکلی در ذخیره‌سازی داده‌ها وجود دارد.");
            }



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
