using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class HPEDL380Repository : RepositoryBase<long, HPEDL380>, IHPEDL380Repository
    {



        public HPEDL380Repository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


    }
}
