using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class juniperhardeningRepository:RepositoryBase<long, JuniperHardening>, IjuniperhardeningRepository
    {



        public juniperhardeningRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;
        

    }
}
