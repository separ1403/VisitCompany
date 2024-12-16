using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class CreateChecklist
    {
        public long Id { get; set; } // شناسه چک‌لیست
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PersonDetail> People { get; set; } = new List<PersonDetail>();
        public long CountEmployees { get; set; }
        public long CountFolowers { get; set; }
        public DateTime CreationDate { get; set; }
        public long CompanyId { get; set; }
        public List<long> AccountIds { get; set; }
        public long GeneralchecklistId { get; set; }
        public long Win2019Id { get; set; }
        public long JuniperId { get; set; }
        public long HpedlId { get; set; }
        public long GeneralchecklistProffId { get; set; }
        public long GeneralchecklistPolId { get; set; }



    }
}
