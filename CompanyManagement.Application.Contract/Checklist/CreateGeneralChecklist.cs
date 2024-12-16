using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateGeneralChecklist
    {
        public string Name { get; set; }
        public long OrganizationalSecurityStatusScore { get; set; }//
        public string OrganizationalSecurityStatus { get; set; }//
        public long SecurityManagerStatusScore { get; set; }//
        public string SecurityManagerStatus { get; set; }//
        public long SecurityPolicyStatusScore { get; set; }//
        public string SecurityPolicyStatus { get; set; }//
        public long SecurityChangeApprovalStatusScore { get; set; }//
        public string SecurityChangeApprovalStatus { get; set; }//
        public long ThirdPartyServiceStatusScore { get; set; }//
        public string ThirdPartyServiceStatus { get; set; }//
        public long PersonnelHiringStatusScore { get; set; }//
        public string PersonnelHiringStatus { get; set; }//
        public long AccessManagementStatusScore { get; set; }//
        public string AccessManagementStatus { get; set; }//
        public long ComplianceManagementStatusScore { get; set; }//
        public string ComplianceManagementStatus { get; set; }//
        public long IncidentResponseStatusScore { get; set; }//
        public string IncidentResponseStatus { get; set; }//
       
        public double AverageGeneral { get; set; }
        public long ChecklistId { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند
        public string FinallDescription { get;  set; }





    }
}
