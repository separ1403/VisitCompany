using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;

namespace CompanyManagement.Application.Contract.Company
{
    public  class CreatePeopleCompany 
    {
        public long Id { get; set; } // شناسه چک‌لیست

        public string NamePeopleCo { get; set; }
        public string RspponsePeopleCo { get; set; }
        public string PhonePeopleCo { get; set; }
        public long CompanyId { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
