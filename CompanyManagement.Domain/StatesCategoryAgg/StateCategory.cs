using CompanyManagement.Domain.AccountAgg;
using Framework.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.StatesCategoryAgg
{
    public  class StateCategory: EntityBase
    {
        public string Name { get; private set; }
       
        public List<Account> Accounts { get; private set; }
        public List<Company> companies { get; private set; }



        public StateCategory()
        {
           
        }

        public StateCategory(string name)
        {
            Name = name;
           
        }



        public void Edit(string name)
        {
            Name = name;
        }
    }
}
