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
        public GeneralChecklist(long? organizationalSecurityStatusScore, string? organizationalSecurityStatus, long? securityManagerStatusScore, string? securityManagerStatus, long? securityPolicyStatusScore, string? securityPolicyStatus, long? securityChangeApprovalStatusScore, string? securityChangeApprovalStatus, long? thirdPartyServiceStatusScore, string? thirdPartyServiceStatus, long? personnelHiringStatusScore, string? personnelHiringStatus, long? accessManagementStatusScore, string? accessManagementStatus, long? complianceManagementStatusScore, string? complianceManagementStatus, long? incidentResponseStatusScore, string? incidentResponseStatus, long? networkLogicalPhysicalMapStatusScore, string? networkLogicalPhysicalMapStatus, long? physicalAssetsInventoryStatusScore, string? physicalAssetsInventoryStatus, long? zoningStatusScore, string? zoningStatus, long? accessControlStatusScore, string? accessControlStatus, long? developmentTestOperationsControlStatusScore, string? developmentTestOperationsControlStatus, long? remoteAdministrativeAccessStatusScore, string? remoteAdministrativeAccessStatus, long? secureCodingConfigStatusScore, string? secureCodingConfigStatus, long? securityEvaluationStatusScore, string? securityEvaluationStatus, long? backupStatusScore, string? backupStatus, long? sessionExpirationStatusScore, string? sessionExpirationStatus, long? antivirusStatusScore, string? antivirusStatus, long? updateStatusScore, string? updateStatus, long? wirelessNetworkStatusScore, string? wirelessNetworkStatus, long? passwordPolicyStatusScore, string? passwordPolicyStatus, long? dataDestructionStatusScore, string? dataDestructionStatus, long? logManagementStatusScore, string? logManagementStatus, long? clockSynchronizationStatusScore, string? clockSynchronizationStatus, long? authenticationStatusScore, string? authenticationStatus, long? businessIdentificationStatusScore, string? businessIdentificationStatus, long? entryExitManagementStatusScore, string? entryExitManagementStatus, long? cCTVStatusScore, string? cCTVStatus, long? hostingServiceStatusScore, string? hostingServiceStatus, long? privacyPolicyStatusScore, string? privacyPolicyStatus, long? publicComplaintsStatusScore, string? publicComplaintsStatus, long? cyberAttackResponseStatusScore, string? cyberAttackResponseStatus, long? dataSalesTradeStatusScore, string? dataSalesTradeStatus, long? financialPaymentPlatformStatusScore, string? financialPaymentPlatformStatus, long? userDataCollectionStatusScore, string? userDataCollectionStatus, long? employeeTrainingStatusScore, string? employeeTrainingStatus , string finallDescription)
        {
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
            NetworkLogicalPhysicalMapStatusScore=networkLogicalPhysicalMapStatusScore;
            NetworkLogicalPhysicalMapStatus=networkLogicalPhysicalMapStatus;
            PhysicalAssetsInventoryStatusScore=physicalAssetsInventoryStatusScore;
            PhysicalAssetsInventoryStatus=physicalAssetsInventoryStatus;
            ZoningStatusScore=zoningStatusScore;
            ZoningStatus=zoningStatus;
            AccessControlStatusScore=accessControlStatusScore;
            AccessControlStatus=accessControlStatus;
            DevelopmentTestOperationsControlStatusScore=developmentTestOperationsControlStatusScore;
            DevelopmentTestOperationsControlStatus=developmentTestOperationsControlStatus;
            RemoteAdministrativeAccessStatusScore=remoteAdministrativeAccessStatusScore;
            RemoteAdministrativeAccessStatus=remoteAdministrativeAccessStatus;
            SecureCodingConfigStatusScore=secureCodingConfigStatusScore;
            SecureCodingConfigStatus=secureCodingConfigStatus;
            SecurityEvaluationStatusScore=securityEvaluationStatusScore;
            SecurityEvaluationStatus=securityEvaluationStatus;
            BackupStatusScore=backupStatusScore;
            BackupStatus=backupStatus;
            SessionExpirationStatusScore=sessionExpirationStatusScore;
            SessionExpirationStatus=sessionExpirationStatus;
            AntivirusStatusScore=antivirusStatusScore;
            AntivirusStatus=antivirusStatus;
            UpdateStatusScore=updateStatusScore;
            UpdateStatus=updateStatus;
            WirelessNetworkStatusScore=wirelessNetworkStatusScore;
            WirelessNetworkStatus=wirelessNetworkStatus;
            PasswordPolicyStatusScore=passwordPolicyStatusScore;
            PasswordPolicyStatus=passwordPolicyStatus;
            DataDestructionStatusScore=dataDestructionStatusScore;
            DataDestructionStatus=dataDestructionStatus;
            LogManagementStatusScore=logManagementStatusScore;
            LogManagementStatus=logManagementStatus;
            ClockSynchronizationStatusScore=clockSynchronizationStatusScore;
            ClockSynchronizationStatus=clockSynchronizationStatus;
            AuthenticationStatusScore=authenticationStatusScore;
            AuthenticationStatus=authenticationStatus;
            BusinessIdentificationStatusScore=businessIdentificationStatusScore;
            BusinessIdentificationStatus=businessIdentificationStatus;
            EntryExitManagementStatusScore=entryExitManagementStatusScore;
            EntryExitManagementStatus=entryExitManagementStatus;
            CCTVStatusScore=cCTVStatusScore;
            CCTVStatus=cCTVStatus;
            HostingServiceStatusScore=hostingServiceStatusScore;
            HostingServiceStatus=hostingServiceStatus;
            PrivacyPolicyStatusScore=privacyPolicyStatusScore;
            PrivacyPolicyStatus=privacyPolicyStatus;
            PublicComplaintsStatusScore=publicComplaintsStatusScore;
            PublicComplaintsStatus=publicComplaintsStatus;
            CyberAttackResponseStatusScore=cyberAttackResponseStatusScore;
            CyberAttackResponseStatus=cyberAttackResponseStatus;
            DataSalesTradeStatusScore=dataSalesTradeStatusScore;
            DataSalesTradeStatus=dataSalesTradeStatus;
            FinancialPaymentPlatformStatusScore=financialPaymentPlatformStatusScore;
            FinancialPaymentPlatformStatus=financialPaymentPlatformStatus;
            UserDataCollectionStatusScore=userDataCollectionStatusScore;
            UserDataCollectionStatus=userDataCollectionStatus;
            EmployeeTrainingStatusScore=employeeTrainingStatusScore;
            EmployeeTrainingStatus=employeeTrainingStatus;
            IsCompleted = true;
            FinallDescription=finallDescription;
        }

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
        public string? IncidentResponseStatus { get; private set; }//
        public long? NetworkLogicalPhysicalMapStatusScore { get; private set; }//
        public string? NetworkLogicalPhysicalMapStatus { get; private set; }//
        public long? PhysicalAssetsInventoryStatusScore { get; private set; }//
        public string? PhysicalAssetsInventoryStatus { get; private set; }//
        public long? ZoningStatusScore { get; private set; }//
        public string? ZoningStatus { get; private set; }//
        public long? AccessControlStatusScore { get; private set; }//
        public string? AccessControlStatus { get; private set; }
        public long? DevelopmentTestOperationsControlStatusScore { get; private set; }//
        public string? DevelopmentTestOperationsControlStatus { get; private set; }//
        public long? RemoteAdministrativeAccessStatusScore { get; private set; }//
        public string? RemoteAdministrativeAccessStatus { get; private set; }//
        public long? SecureCodingConfigStatusScore { get; private set; }//
        public string? SecureCodingConfigStatus { get; private set; }//
        public long? SecurityEvaluationStatusScore { get; private set; }//
        public string? SecurityEvaluationStatus { get; private set; }//
        public long? BackupStatusScore { get; private set; }//
        public string? BackupStatus { get; private set; }//
        public long? SessionExpirationStatusScore { get; private set; }//
        public string? SessionExpirationStatus { get; private set; }//
        public long? AntivirusStatusScore { get; private set; }//
        public string? AntivirusStatus { get; private set; }//
        public long? UpdateStatusScore { get; private set; }//
        public string? UpdateStatus { get; private set; }//
        public long? WirelessNetworkStatusScore { get; private set; }//
        public string? WirelessNetworkStatus { get; private set; }//
        public long? PasswordPolicyStatusScore { get; private set; }//
        public string? PasswordPolicyStatus { get; private set; }//
        public long? DataDestructionStatusScore { get; private set; }//
        public string? DataDestructionStatus { get; private set; }//
        public long? LogManagementStatusScore { get; private set; }//
        public string? LogManagementStatus { get; private set; }//
        public long? ClockSynchronizationStatusScore { get; private set; }//
        public string? ClockSynchronizationStatus { get; private set; }//
        public long? AuthenticationStatusScore { get; private set; }//
        public string? AuthenticationStatus { get; private set; }//
        public long? BusinessIdentificationStatusScore { get; private set; }//
        public string? BusinessIdentificationStatus { get; private set; }//
        public long? EntryExitManagementStatusScore { get; private set; }//
        public string? EntryExitManagementStatus { get; private set; }//
        public long? CCTVStatusScore { get; private set; }//
        public string? CCTVStatus { get; private set; }//
        public long? HostingServiceStatusScore { get; private set; }//
        public string? HostingServiceStatus { get; private set; }//
        public long? PrivacyPolicyStatusScore { get; private set; }//
        public string? PrivacyPolicyStatus { get; private set; }//
        public long? PublicComplaintsStatusScore { get; private set; }//
        public string? PublicComplaintsStatus { get; private set; }//
        public long? CyberAttackResponseStatusScore { get; private set; }//
        public string? CyberAttackResponseStatus { get; private set; }//
        public long? DataSalesTradeStatusScore { get; private set; }//
        public string? DataSalesTradeStatus { get; private set; }//
        public long? FinancialPaymentPlatformStatusScore { get; private set; }//
        public string? FinancialPaymentPlatformStatus { get; private set; }//
        public long? UserDataCollectionStatusScore { get; private set; }//
        public string? UserDataCollectionStatus { get; private set; }//
        public long? EmployeeTrainingStatusScore { get; private set; }//
        public string? EmployeeTrainingStatus { get; private set; }
        public double AverageGeneral { get; private set; }
        public Checklist Checklist { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند
        public string? FinallDescription { get; private set; }




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
            NetworkLogicalPhysicalMapStatusScore ??= 0;
            PhysicalAssetsInventoryStatusScore ??= 0;
            ZoningStatusScore ??= 0;
            AccessControlStatusScore ??= 0;
            DevelopmentTestOperationsControlStatusScore ??= 0;
            RemoteAdministrativeAccessStatusScore ??= 0;
            SecureCodingConfigStatusScore ??= 0;
            SecurityEvaluationStatusScore ??= 0;
            BackupStatusScore ??= 0;
            SessionExpirationStatusScore ??= 0;
            AntivirusStatusScore ??= 0;
            UpdateStatusScore ??= 0;
            WirelessNetworkStatusScore ??= 0;
            PasswordPolicyStatusScore ??= 0;
            DataDestructionStatusScore ??= 0;
            LogManagementStatusScore ??= 0;
            ClockSynchronizationStatusScore ??= 0;
            AuthenticationStatusScore ??= 0;
            BusinessIdentificationStatusScore ??= 0;
            EntryExitManagementStatusScore ??= 0;
            CCTVStatusScore ??= 0;
            HostingServiceStatusScore ??= 0;
            PrivacyPolicyStatusScore ??= 0;
            PublicComplaintsStatusScore ??= 0;
            CyberAttackResponseStatusScore ??= 0;
            DataSalesTradeStatusScore ??= 0;
            FinancialPaymentPlatformStatusScore ??= 0;
            UserDataCollectionStatusScore ??= 0;
            EmployeeTrainingStatusScore ??= 0;

            var Sum = command.OrganizationalSecurityStatusScore + command.SecurityManagerStatusScore + command.SecurityPolicyStatusScore +
                      command.SecurityChangeApprovalStatusScore + command.ThirdPartyServiceStatusScore + command.PersonnelHiringStatusScore +
                      command.AccessManagementStatusScore + command.ComplianceManagementStatusScore + command.IncidentResponseStatusScore +
                      command.NetworkLogicalPhysicalMapStatusScore + command.PhysicalAssetsInventoryStatusScore + command.ZoningStatusScore +
                      command.AccessControlStatusScore + command.DevelopmentTestOperationsControlStatusScore +
                      command.RemoteAdministrativeAccessStatusScore + command.SecureCodingConfigStatusScore +
                      command.SecurityEvaluationStatusScore + command.BackupStatusScore + command.SessionExpirationStatusScore +
                      command.AntivirusStatusScore + command.UpdateStatusScore + command.WirelessNetworkStatusScore +
                      command.PasswordPolicyStatusScore + command.DataDestructionStatusScore + command.LogManagementStatusScore +
                      command.ClockSynchronizationStatusScore + command.AuthenticationStatusScore + command.BusinessIdentificationStatusScore +
                      command.EntryExitManagementStatusScore + command.CCTVStatusScore + command.HostingServiceStatusScore +
                      command.PrivacyPolicyStatusScore + command.PublicComplaintsStatusScore + command.CyberAttackResponseStatusScore +
                      command.DataSalesTradeStatusScore + command.FinancialPaymentPlatformStatusScore + command.UserDataCollectionStatusScore +
                      command.EmployeeTrainingStatusScore;

            var Avg = ((double)Sum / 18);
            var Average = Math.Round(Avg, 2);
            AverageGeneral = Average;
        }

    }
}
