using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public  class GeneralChecklist :EntityBase
    {
        public GeneralChecklist( long? organizationalSecurityStatusScore, string? organizationalSecurityStatus, long? securityManagerStatusScore, string? securityManagerStatus, long? securityPolicyStatusScore, string? securityPolicyStatus, long? securityChangeApprovalStatusScore, string? securityChangeApprovalStatus, long? thirdPartyServiceStatusScore, string? thirdPartyServiceStatus, long? personnelHiringStatusScore, string? personnelHiringStatus, long? accessManagementStatusScore, string? accessManagementStatus, long? complianceManagementStatusScore, string? complianceManagementStatus, long? incidentResponseStatusScore, string? incidentResponseStatus, string finallDescription)
        {
            Name = "چک لیست عمومی";
            OrganizationalSecurityStatusScore=organizationalSecurityStatusScore;
            OrganizationalSecurityStatus=organizationalSecurityStatus;
            SecurityManagerStatusScore=securityManagerStatusScore;
            SecurityManagerStatus=securityManagerStatus;
            SecurityPolicyStatusScore=securityPolicyStatusScore;
            SecurityPolicyStatus=securityPolicyStatus;
            SecurityChangeApprovalStatusScore=securityChangeApprovalStatusScore;
            SecurityChangeApprovalStatus=securityChangeApprovalStatus;
            ThirdPartyServiceStatusScore=thirdPartyServiceStatusScore;
            ThirdPartyServiceStatus=thirdPartyServiceStatus;
            PersonnelHiringStatusScore=personnelHiringStatusScore;
            PersonnelHiringStatus=personnelHiringStatus;
            AccessManagementStatusScore=accessManagementStatusScore;
            AccessManagementStatus=accessManagementStatus;
            ComplianceManagementStatusScore=complianceManagementStatusScore;
            ComplianceManagementStatus=complianceManagementStatus;
            IncidentResponseStatusScore=incidentResponseStatusScore;
            IncidentResponseStatus=incidentResponseStatus;
           
            IsCompleted = true;
            FinallDescription=finallDescription;
        }
        public string Name { get; private set; }
        public long? OrganizationalSecurityStatusScore { get; private set; }//
        public string? OrganizationalSecurityStatus { get; private set; }//
        public long? SecurityManagerStatusScore { get; private set; }//
        public string? SecurityManagerStatus { get; private set; }//
        public long? SecurityPolicyStatusScore { get; private set; }//
        public string? SecurityPolicyStatus { get; private set; }//
        public long? SecurityChangeApprovalStatusScore { get; private set; }//
        public string? SecurityChangeApprovalStatus { get; private set; }//
        public long? ThirdPartyServiceStatusScore { get; private set; }//
        public string? ThirdPartyServiceStatus { get; private set; }//
        public long? PersonnelHiringStatusScore { get; private set; }//
        public string? PersonnelHiringStatus { get; private set; }//
        public long? AccessManagementStatusScore { get; private set; }//
        public string? AccessManagementStatus { get; private set; }//
        public long? ComplianceManagementStatusScore { get; private set; }//
        public string? ComplianceManagementStatus { get; private set; }//
        public long? IncidentResponseStatusScore { get; private set; }//
        public string? IncidentResponseStatus { get; private set; }// تا اینجا برای عمومی مدیریتی
       
        //  ز اینجا به بعد مشترکات
        public double AverageGeneral { get; private set; }
        public Checklist Checklist { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند
        public string? FinallDescription { get; private set; }
        public string? UniqueCode { get; set; }



        public void AverageGeneralcal(CreateGeneralChecklist command)
        {
            // بررسی وجود مقدار برای متغیرهای مربوطه و مقداردهی پیش‌فرض در صورت لزوم
            //اگر مقدار نال باشد 0 به ان میدهد و اگر صفر نباشد تغییری در آن نمیدهد
            OrganizationalSecurityStatusScore ??= 0;
            SecurityManagerStatusScore ??= 0;
            SecurityPolicyStatusScore ??= 0;
            SecurityChangeApprovalStatusScore ??= 0;
            ThirdPartyServiceStatusScore ??= 0;
            PersonnelHiringStatusScore ??= 0;
            AccessManagementStatusScore ??= 0;
            ComplianceManagementStatusScore ??= 0;
            IncidentResponseStatusScore ??= 0;
           

            var Sum = command.OrganizationalSecurityStatusScore + command.SecurityManagerStatusScore + command.SecurityPolicyStatusScore +
                      command.SecurityChangeApprovalStatusScore + command.ThirdPartyServiceStatusScore + command.PersonnelHiringStatusScore +
                      command.AccessManagementStatusScore + command.ComplianceManagementStatusScore + command.IncidentResponseStatusScore ;

            var Avg = ((double)Sum / 9);
            var Average = Math.Round(Avg, 2);
            AverageGeneral = Average;
        }

    }
}
