using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateGeneralChecklist
    {
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
        public long NetworkLogicalPhysicalMapStatusScore { get; set; }//
        public string NetworkLogicalPhysicalMapStatus { get; set; }//
        public long PhysicalAssetsInventoryStatusScore { get; set; }//
        public string PhysicalAssetsInventoryStatus { get; set; }//
        public long ZoningStatusScore { get; set; }//
        public string ZoningStatus { get; set; }//
        public long AccessControlStatusScore { get; set; }//
        public string AccessControlStatus { get; set; }
        public long DevelopmentTestOperationsControlStatusScore { get; set; }//
        public string DevelopmentTestOperationsControlStatus { get; set; }//
        public long RemoteAdministrativeAccessStatusScore { get; set; }//
        public string RemoteAdministrativeAccessStatus { get; set; }//
        public long SecureCodingConfigStatusScore { get; set; }//
        public string SecureCodingConfigStatus { get; set; }//
        public long SecurityEvaluationStatusScore { get; set; }//
        public string SecurityEvaluationStatus { get; set; }//
        public long BackupStatusScore { get; set; }//
        public string BackupStatus { get; set; }//
        public long SessionExpirationStatusScore { get; set; }//
        public string SessionExpirationStatus { get; set; }//
        public long AntivirusStatusScore { get; set; }//
        public string AntivirusStatus { get; set; }//
        public long UpdateStatusScore { get; set; }//
        public string UpdateStatus { get; set; }//
        public long WirelessNetworkStatusScore { get; set; }//
        public string WirelessNetworkStatus { get; set; }//
        public long PasswordPolicyStatusScore { get; set; }//
        public string PasswordPolicyStatus { get; set; }//
        public long DataDestructionStatusScore { get; set; }//
        public string DataDestructionStatus { get; set; }//
        public long LogManagementStatusScore { get; set; }//
        public string LogManagementStatus { get; set; }//
        public long ClockSynchronizationStatusScore { get; set; }//
        public string ClockSynchronizationStatus { get; set; }//
        public long AuthenticationStatusScore { get; set; }//
        public string AuthenticationStatus { get; set; }//
        public long BusinessIdentificationStatusScore { get; set; }//
        public string BusinessIdentificationStatus { get; set; }//
        public long EntryExitManagementStatusScore { get; set; }//
        public string EntryExitManagementStatus { get; set; }//
        public long CCTVStatusScore { get; set; }//
        public string CCTVStatus { get; set; }//
        public long HostingServiceStatusScore { get; set; }//
        public string HostingServiceStatus { get; set; }//
        public long PrivacyPolicyStatusScore { get; set; }//
        public string PrivacyPolicyStatus { get; set; }//
        public long PublicComplaintsStatusScore { get; set; }//
        public string PublicComplaintsStatus { get; set; }//
        public long CyberAttackResponseStatusScore { get; set; }//
        public string CyberAttackResponseStatus { get; set; }//
        public long DataSalesTradeStatusScore { get; set; }//
        public string DataSalesTradeStatus { get; set; }//
        public long FinancialPaymentPlatformStatusScore { get; set; }//
        public string FinancialPaymentPlatformStatus { get; set; }//
        public long UserDataCollectionStatusScore { get; set; }//
        public string UserDataCollectionStatus { get; set; }//
        public long EmployeeTrainingStatusScore { get; set; }//
        public string EmployeeTrainingStatus { get; set; }
        public double AverageGeneral { get; set; }
        public long ChecklistId { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند




    }
}
