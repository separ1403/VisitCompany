﻿using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.ChecklistAgg
{

    public interface IWin2019Repository : IRepository<long, Win2019>
    {
        EditWin2019Checklist Getdetails(long id);

    }
}
