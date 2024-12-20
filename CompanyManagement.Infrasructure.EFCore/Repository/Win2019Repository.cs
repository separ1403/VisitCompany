﻿using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class Win2019Repository : RepositoryBase<long, Win2019>, IWin2019Repository
    {
        
        public Win2019Repository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


        public EditWin2019Checklist Getdetails(long id)
        {
            return _companyContext.Win2019s.Select(x => new EditWin2019Checklist()
            {
                Id = x.Id,
                // AccountIds = x.AccountId,
                //CompanyId = x.CompanyId ?? 0,
                //Description = x.Description,
                IsCompleted = x.IsCompleted,


            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
