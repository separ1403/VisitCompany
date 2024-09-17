using CompanyManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace CompanyManagement.Domain.LicenceCategoryAgg
{
    public class LicenceCategory:EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Company> Companies { get; private set; }


        public LicenceCategory()
        {
            Companies = new List<Company>();
        }

        public LicenceCategory(string name, string description)
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
