using CompanyManagement.Application.Contract.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.CompanyAgg
{
    public  interface IApiService
    {
        Task<CompanyResponse> GetCompanyDetailsAsync(string nationalCode);

    }
}
