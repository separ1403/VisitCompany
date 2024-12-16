using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.LicenceCategory
{
    public class LicenceCategoryViewModel
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public string Refrence { get; set; }
        public string  Count { get; set; }
        public bool Status { get; set; }
        public string CompanyName { get; set; }

        public string Fullname { get; set; }




    }
}

