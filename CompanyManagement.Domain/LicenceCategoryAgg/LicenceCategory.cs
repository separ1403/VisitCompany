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
        public string Refrence { get; private set; }
        public bool Status { get; private set; }
        public string? Fullname { get; private set; }
        public string? CompanyName { get; private set; }



        public LicenceCategory()
        {
            Companies = new List<Company>();
        }

        public LicenceCategory(string name, string description, string refrence ,bool status , string? fullname , string? companyname )
        {
            Name = name;
            Description = description;
            Refrence = refrence;
            Status = status;
            Fullname = fullname;
            CompanyName = companyname;


        }

       

        public void Edit(string name, string description, string refrence, bool status)
        {
            Name = name;
            Description = description;
            Refrence = refrence;
            Status=status;
        }


        public void ChangeActiveMode()
        {
            Status = false;
        }

        public void ChangeToActiveMode()
        {
            Status = true;
        }
    }

   
}
