using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class Win2019Repository : RepositoryBase<long, Win2019>, IWin2019Repository
    {
        
        public Win2019Repository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


    }
}
