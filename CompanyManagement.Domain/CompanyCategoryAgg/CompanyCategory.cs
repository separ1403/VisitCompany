using CompanyManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace CompanyManagement.Domain.CompanyCategoryAgg
{
    public class CompanyCategory:EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Company> Companies { get; private set; }


        public CompanyCategory()
        {
            Companies = new List<Company>();
        }

        public CompanyCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

       

        public void Edit(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

   
}
