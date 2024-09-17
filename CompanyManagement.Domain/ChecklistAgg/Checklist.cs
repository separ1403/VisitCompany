using CompanyManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using AccountManagement;
using AccountManagement.Domain;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.AccountAgg;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class Checklist : EntityBase
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public string? NamePeopleCo { get; set; } 
        public string? RspponsePeopleCo { get;private set; }
        public string? PhonePeopleCo { get; private set; }
        public long? CountEmployees { get; private set; } 
        public long? CountFolowers { get; private set; }
        public long? CompanyId { get; private set; }
        public List<long>? AccountIds { get; private set; }
        public Company? Company { get; private set; }
        public List<Account>? Accounts { get; private set; }


        //general 

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

        //professional

        public long? JuniperHardeningID { get; private set; }
        public long? HPEDL380ID { get; private set; }
        public long? Win2019ID { get; private set; }

        // Navigation properties for specialized checklists
        public JuniperHardening? JuniperHardening { get; set; }
        public HPEDL380? HPEDL380 { get; set; }
        public Win2019? Win2019 { get; set; }

        public Checklist(string title, string description, string namePeopleCo, string rspponsePeopleCo, string phonePeopleCo, long countEmployees, long countFolowers, long companyId,List<long> accountId, long organizationalSecurityStatusScore, string organizationalSecurityStatus, long securityManagerStatusScore, string securityManagerStatus, long securityPolicyStatusScore, string securityPolicyStatus, long securityChangeApprovalStatusScore, string securityChangeApprovalStatus, long thirdPartyServiceStatusScore, string thirdPartyServiceStatus, long personnelHiringStatusScore, string personnelHiringStatus, long accessManagementStatusScore, string accessManagementStatus, long complianceManagementStatusScore, string complianceManagementStatus, long incidentResponseStatusScore, string incidentResponseStatus, long networkLogicalPhysicalMapStatusScore, string networkLogicalPhysicalMapStatus, long physicalAssetsInventoryStatusScore, string physicalAssetsInventoryStatus, long zoningStatusScore, string zoningStatus, long accessControlStatusScore, string accessControlStatus, long developmentTestOperationsControlStatusScore, string developmentTestOperationsControlStatus, long remoteAdministrativeAccessStatusScore, string remoteAdministrativeAccessStatus, long secureCodingConfigStatusScore, string secureCodingConfigStatus, long securityEvaluationStatusScore, string securityEvaluationStatus, long backupStatusScore, string backupStatus, long sessionExpirationStatusScore, string sessionExpirationStatus, long antivirusStatusScore, string antivirusStatus, long updateStatusScore, string updateStatus, long wirelessNetworkStatusScore, string wirelessNetworkStatus, long passwordPolicyStatusScore, string passwordPolicyStatus, long dataDestructionStatusScore, string dataDestructionStatus, long logManagementStatusScore, string logManagementStatus, long clockSynchronizationStatusScore, string clockSynchronizationStatus, long authenticationStatusScore, string authenticationStatus, long businessIdentificationStatusScore, string businessIdentificationStatus, long entryExitManagementStatusScore, string entryExitManagementStatus, long cctvStatusScore, string cctvStatus, long hostingServiceStatusScore, string hostingServiceStatus, long privacyPolicyStatusScore, string privacyPolicyStatus, long publicComplaintsStatusScore, string publicComplaintsStatus, long cyberAttackResponseStatusScore, string cyberAttackResponseStatus, long dataSalesTradeStatusScore, string dataSalesTradeStatus, long financialPaymentPlatformStatusScore, string financialPaymentPlatformStatus, long userDataCollectionStatusScore, string userDataCollectionStatus, long employeeTrainingStatusScore, string employeeTrainingStatus/*, long junuperhardeningID, long hPEDL380ID*/)
        {
            Title = title;
            Description = description;
            NamePeopleCo = namePeopleCo;
            RspponsePeopleCo = rspponsePeopleCo;
            PhonePeopleCo = phonePeopleCo;
            CountEmployees = countEmployees;
            CountFolowers = countFolowers;
            CompanyId = companyId;
            AccountIds = accountId;
            OrganizationalSecurityStatusScore = organizationalSecurityStatusScore;
            OrganizationalSecurityStatus = organizationalSecurityStatus;
            SecurityManagerStatusScore = securityManagerStatusScore;
            SecurityManagerStatus = securityManagerStatus;
            SecurityPolicyStatusScore = securityPolicyStatusScore;
            SecurityPolicyStatus = securityPolicyStatus;
            SecurityChangeApprovalStatusScore = securityChangeApprovalStatusScore;
            SecurityChangeApprovalStatus = securityChangeApprovalStatus;
            ThirdPartyServiceStatusScore = thirdPartyServiceStatusScore;
            ThirdPartyServiceStatus = thirdPartyServiceStatus;
            PersonnelHiringStatusScore = personnelHiringStatusScore;
            PersonnelHiringStatus = personnelHiringStatus;
            AccessManagementStatusScore = accessManagementStatusScore;
            AccessManagementStatus = accessManagementStatus;
            ComplianceManagementStatusScore = complianceManagementStatusScore;
            ComplianceManagementStatus = complianceManagementStatus;
            IncidentResponseStatusScore = incidentResponseStatusScore;
            IncidentResponseStatus = incidentResponseStatus;
            NetworkLogicalPhysicalMapStatusScore = networkLogicalPhysicalMapStatusScore;
            NetworkLogicalPhysicalMapStatus = networkLogicalPhysicalMapStatus;
            PhysicalAssetsInventoryStatusScore = physicalAssetsInventoryStatusScore;
            PhysicalAssetsInventoryStatus = physicalAssetsInventoryStatus;
            ZoningStatusScore = zoningStatusScore;
            ZoningStatus = zoningStatus;
            AccessControlStatusScore = accessControlStatusScore;
            AccessControlStatus = accessControlStatus;
            DevelopmentTestOperationsControlStatusScore = developmentTestOperationsControlStatusScore;
            DevelopmentTestOperationsControlStatus = developmentTestOperationsControlStatus;
            RemoteAdministrativeAccessStatusScore = remoteAdministrativeAccessStatusScore;
            RemoteAdministrativeAccessStatus = remoteAdministrativeAccessStatus;
            SecureCodingConfigStatusScore = secureCodingConfigStatusScore;
            SecureCodingConfigStatus = secureCodingConfigStatus;
            SecurityEvaluationStatusScore = securityEvaluationStatusScore;
            SecurityEvaluationStatus = securityEvaluationStatus;
            BackupStatusScore = backupStatusScore;
            BackupStatus = backupStatus;
            SessionExpirationStatusScore = sessionExpirationStatusScore;
            SessionExpirationStatus = sessionExpirationStatus;
            AntivirusStatusScore = antivirusStatusScore;
            AntivirusStatus = antivirusStatus;
            UpdateStatusScore = updateStatusScore;
            UpdateStatus = updateStatus;
            WirelessNetworkStatusScore = wirelessNetworkStatusScore;
            WirelessNetworkStatus = wirelessNetworkStatus;
            PasswordPolicyStatusScore = passwordPolicyStatusScore;
            PasswordPolicyStatus = passwordPolicyStatus;
            DataDestructionStatusScore = dataDestructionStatusScore;
            DataDestructionStatus = dataDestructionStatus;
            LogManagementStatusScore = logManagementStatusScore;
            LogManagementStatus = logManagementStatus;
            ClockSynchronizationStatusScore = clockSynchronizationStatusScore;
            ClockSynchronizationStatus = clockSynchronizationStatus;
            AuthenticationStatusScore = authenticationStatusScore;
            AuthenticationStatus = authenticationStatus;
            BusinessIdentificationStatusScore = businessIdentificationStatusScore;
            BusinessIdentificationStatus = businessIdentificationStatus;
            EntryExitManagementStatusScore = entryExitManagementStatusScore;
            EntryExitManagementStatus = entryExitManagementStatus;
            CCTVStatusScore = cctvStatusScore;
            CCTVStatus = cctvStatus;
            HostingServiceStatusScore = hostingServiceStatusScore;
            HostingServiceStatus = hostingServiceStatus;
            PrivacyPolicyStatusScore = privacyPolicyStatusScore;
            PrivacyPolicyStatus = privacyPolicyStatus;
            PublicComplaintsStatusScore = publicComplaintsStatusScore;
            PublicComplaintsStatus = publicComplaintsStatus;
            CyberAttackResponseStatusScore = cyberAttackResponseStatusScore;
            CyberAttackResponseStatus = cyberAttackResponseStatus;
            DataSalesTradeStatusScore = dataSalesTradeStatusScore;
            DataSalesTradeStatus = dataSalesTradeStatus;
            FinancialPaymentPlatformStatusScore = financialPaymentPlatformStatusScore;
            FinancialPaymentPlatformStatus = financialPaymentPlatformStatus;
            UserDataCollectionStatusScore = userDataCollectionStatusScore;
            UserDataCollectionStatus = userDataCollectionStatus;
            EmployeeTrainingStatusScore = employeeTrainingStatusScore;
            EmployeeTrainingStatus = employeeTrainingStatus;
            
            CreationDate = DateTime.Now;
            //JuniperHardeningID = junuperhardeningID;
            //HPEDL380ID = hPEDL380ID;
           
        }
        public Checklist()
        {
            // Parameterless constructor
        }

        public void Editjunior(long juniperHardeningID)
        {
            if (juniperHardeningID != 0)
            {
                JuniperHardeningID = juniperHardeningID;
            }
        }


        public void EditHPEDL380(long hPEDL380ID)
        {
            if (hPEDL380ID != 0)
            {
                HPEDL380ID = hPEDL380ID;
            }
        }

        public void EditWin2019(long win2019ID)
        {
            if (win2019ID != 0)
            {
                Win2019ID = win2019ID;
            }
        }

        public void Edit(long organizationalSecurityStatusScore, string organizationalSecurityStatus, long securityManagerStatusScore, string securityManagerStatus, long securityPolicyStatusScore, string securityPolicyStatus, long securityChangeApprovalStatusScore, string securityChangeApprovalStatus, long thirdPartyServiceStatusScore, string thirdPartyServiceStatus, long personnelHiringStatusScore, string personnelHiringStatus, long accessManagementStatusScore, string accessManagementStatus, long complianceManagementStatusScore, string complianceManagementStatus, long incidentResponseStatusScore, string incidentResponseStatus, long networkLogicalPhysicalMapStatusScore, string networkLogicalPhysicalMapStatus, long physicalAssetsInventoryStatusScore, string physicalAssetsInventoryStatus, long zoningStatusScore, string zoningStatus, long accessControlStatusScore, string accessControlStatus, long developmentTestOperationsControlStatusScore, string developmentTestOperationsControlStatus, long remoteAdministrativeAccessStatusScore, string remoteAdministrativeAccessStatus, long secureCodingConfigStatusScore, string secureCodingConfigStatus, long securityEvaluationStatusScore, string securityEvaluationStatus, long backupStatusScore, string backupStatus, long sessionExpirationStatusScore, string sessionExpirationStatus, long antivirusStatusScore, string antivirusStatus, long updateStatusScore, string updateStatus, long wirelessNetworkStatusScore, string wirelessNetworkStatus, long passwordPolicyStatusScore, string passwordPolicyStatus, long dataDestructionStatusScore, string dataDestructionStatus, long logManagementStatusScore, string logManagementStatus, long clockSynchronizationStatusScore, string clockSynchronizationStatus, long authenticationStatusScore, string authenticationStatus, long businessIdentificationStatusScore, string businessIdentificationStatus, long entryExitManagementStatusScore, string entryExitManagementStatus, long cctvStatusScore, string cctvStatus, long hostingServiceStatusScore, string hostingServiceStatus, long privacyPolicyStatusScore, string privacyPolicyStatus, long publicComplaintsStatusScore, string publicComplaintsStatus, long cyberAttackResponseStatusScore, string cyberAttackResponseStatus, long dataSalesTradeStatusScore, string dataSalesTradeStatus, long financialPaymentPlatformStatusScore, string financialPaymentPlatformStatus, long userDataCollectionStatusScore, string userDataCollectionStatus, long employeeTrainingStatusScore, string employeeTrainingStatus,double averagegeneral)
        {

            if (organizationalSecurityStatusScore != 0)
            {
                OrganizationalSecurityStatusScore = organizationalSecurityStatusScore;
            }

            if (!string.IsNullOrEmpty(organizationalSecurityStatus))
            {
                OrganizationalSecurityStatus = organizationalSecurityStatus;
            }

            if (securityManagerStatusScore != 0)
            {
                SecurityManagerStatusScore = securityManagerStatusScore;
            }

            if (!string.IsNullOrEmpty(securityManagerStatus))
            {
                SecurityManagerStatus = securityManagerStatus;
            }

            
           

            if (securityPolicyStatusScore != 0)
            {
                SecurityPolicyStatusScore = securityPolicyStatusScore;
            }

            if (!string.IsNullOrEmpty(securityPolicyStatus))
            {
                SecurityPolicyStatus = securityPolicyStatus;
            }

            if (securityChangeApprovalStatusScore != 0)
            {
                SecurityChangeApprovalStatusScore = securityChangeApprovalStatusScore;
            }

            if (!string.IsNullOrEmpty(securityChangeApprovalStatus))
            {
                SecurityChangeApprovalStatus = securityChangeApprovalStatus;
            }

            if (thirdPartyServiceStatusScore != 0)
            {
                ThirdPartyServiceStatusScore = thirdPartyServiceStatusScore;
            }

            if (!string.IsNullOrEmpty(thirdPartyServiceStatus))
            {
                ThirdPartyServiceStatus = thirdPartyServiceStatus;
            }

            if (personnelHiringStatusScore != 0)
            {
                PersonnelHiringStatusScore = personnelHiringStatusScore;
            }

            if (!string.IsNullOrEmpty(personnelHiringStatus))
            {
                PersonnelHiringStatus = personnelHiringStatus;
            }

            if (accessManagementStatusScore != 0)
            {
                AccessManagementStatusScore = accessManagementStatusScore;
            }

            if (!string.IsNullOrEmpty(accessManagementStatus))
            {
                AccessManagementStatus = accessManagementStatus;
            }

            if (complianceManagementStatusScore != 0)
            {
                ComplianceManagementStatusScore = complianceManagementStatusScore;
            }

            if (!string.IsNullOrEmpty(complianceManagementStatus))
            {
                ComplianceManagementStatus = complianceManagementStatus;
            }

            if (incidentResponseStatusScore != 0)
            {
                IncidentResponseStatusScore = incidentResponseStatusScore;
            }

            if (!string.IsNullOrEmpty(incidentResponseStatus))
            {
                IncidentResponseStatus = incidentResponseStatus;
            }

            if (networkLogicalPhysicalMapStatusScore != 0)
            {
                NetworkLogicalPhysicalMapStatusScore = networkLogicalPhysicalMapStatusScore;
            }

            if (!string.IsNullOrEmpty(networkLogicalPhysicalMapStatus))
            {
                NetworkLogicalPhysicalMapStatus = networkLogicalPhysicalMapStatus;
            }

            if (physicalAssetsInventoryStatusScore != 0)
            {
                PhysicalAssetsInventoryStatusScore = physicalAssetsInventoryStatusScore;
            }

            if (!string.IsNullOrEmpty(physicalAssetsInventoryStatus))
            {
                PhysicalAssetsInventoryStatus = physicalAssetsInventoryStatus;
            }

            if (zoningStatusScore != 0)
            {
                ZoningStatusScore = zoningStatusScore;
            }

            if (!string.IsNullOrEmpty(zoningStatus))
            {
                ZoningStatus = zoningStatus;
            }

            if (accessControlStatusScore != 0)
            {
                AccessControlStatusScore = accessControlStatusScore;
            }

            if (!string.IsNullOrEmpty(accessControlStatus))
            {
                AccessControlStatus = accessControlStatus;
            }

            if (developmentTestOperationsControlStatusScore != 0)
            {
                DevelopmentTestOperationsControlStatusScore = developmentTestOperationsControlStatusScore;
            }

            if (!string.IsNullOrEmpty(developmentTestOperationsControlStatus))
            {
                DevelopmentTestOperationsControlStatus = developmentTestOperationsControlStatus;
            }

            if (remoteAdministrativeAccessStatusScore != 0)
            {
                RemoteAdministrativeAccessStatusScore = remoteAdministrativeAccessStatusScore;
            }

            if (!string.IsNullOrEmpty(remoteAdministrativeAccessStatus))
            {
                RemoteAdministrativeAccessStatus = remoteAdministrativeAccessStatus;
            }

            if (secureCodingConfigStatusScore != 0)
            {
                SecureCodingConfigStatusScore = secureCodingConfigStatusScore;
            }

            if (!string.IsNullOrEmpty(secureCodingConfigStatus))
            {
                SecureCodingConfigStatus = secureCodingConfigStatus;
            }

            if (securityEvaluationStatusScore != 0)
            {
                SecurityEvaluationStatusScore = securityEvaluationStatusScore;
            }

            if (!string.IsNullOrEmpty(securityEvaluationStatus))
            {
                SecurityEvaluationStatus = securityEvaluationStatus;
            }

            if (backupStatusScore != 0)
            {
                BackupStatusScore = backupStatusScore;
            }

            if (!string.IsNullOrEmpty(backupStatus))
            {
                BackupStatus = backupStatus;
            }

            if (sessionExpirationStatusScore != 0)
            {
                SessionExpirationStatusScore = sessionExpirationStatusScore;
            }

            if (!string.IsNullOrEmpty(sessionExpirationStatus))
            {
                SessionExpirationStatus = sessionExpirationStatus;
            }

            if (antivirusStatusScore != 0)
            {
                AntivirusStatusScore = antivirusStatusScore;
            }

            if (!string.IsNullOrEmpty(antivirusStatus))
            {
                AntivirusStatus = antivirusStatus;
            }

            if (updateStatusScore != 0)
            {
                UpdateStatusScore = updateStatusScore;
            }

            if (!string.IsNullOrEmpty(updateStatus))
            {
                UpdateStatus = updateStatus;
            }

            if (wirelessNetworkStatusScore != 0)
            {
                WirelessNetworkStatusScore = wirelessNetworkStatusScore;
            }

            if (!string.IsNullOrEmpty(wirelessNetworkStatus))
            {
                WirelessNetworkStatus = wirelessNetworkStatus;
            }

            if (passwordPolicyStatusScore != 0)
            {
                PasswordPolicyStatusScore = passwordPolicyStatusScore;
            }

            if (!string.IsNullOrEmpty(passwordPolicyStatus))
            {
                PasswordPolicyStatus = passwordPolicyStatus;
            }

            if (dataDestructionStatusScore != 0)
            {
                DataDestructionStatusScore = dataDestructionStatusScore;
            }

            if (!string.IsNullOrEmpty(dataDestructionStatus))
            {
                DataDestructionStatus = dataDestructionStatus;
            }

            if (logManagementStatusScore != 0)
            {
                LogManagementStatusScore = logManagementStatusScore;
            }

            if (!string.IsNullOrEmpty(logManagementStatus))
            {
                LogManagementStatus = logManagementStatus;
            }

            if (clockSynchronizationStatusScore != 0)
            {
                ClockSynchronizationStatusScore = clockSynchronizationStatusScore;
            }

            if (!string.IsNullOrEmpty(clockSynchronizationStatus))
            {
                ClockSynchronizationStatus = clockSynchronizationStatus;
            }

            if (authenticationStatusScore != 0)
            {
                AuthenticationStatusScore = authenticationStatusScore;
            }

            if (!string.IsNullOrEmpty(authenticationStatus))
            {
                AuthenticationStatus = authenticationStatus;
            }

            if (businessIdentificationStatusScore != 0)
            {
                BusinessIdentificationStatusScore = businessIdentificationStatusScore;
            }

            if (!string.IsNullOrEmpty(businessIdentificationStatus))
            {
                BusinessIdentificationStatus = businessIdentificationStatus;
            }

            if (entryExitManagementStatusScore != 0)
            {
                EntryExitManagementStatusScore = entryExitManagementStatusScore;
            }

            if (!string.IsNullOrEmpty(entryExitManagementStatus))
            {
                EntryExitManagementStatus = entryExitManagementStatus;
            }

            if (cctvStatusScore != 0)
            {
                CCTVStatusScore = cctvStatusScore;
            }

            if (!string.IsNullOrEmpty(cctvStatus))
            {
                CCTVStatus = cctvStatus;
            }

            if (hostingServiceStatusScore != 0)
            {
                HostingServiceStatusScore = hostingServiceStatusScore;
            }

            if (!string.IsNullOrEmpty(hostingServiceStatus))
            {
                HostingServiceStatus = hostingServiceStatus;
            }

            if (privacyPolicyStatusScore != 0)
            {
                PrivacyPolicyStatusScore = privacyPolicyStatusScore;
            }

            if (!string.IsNullOrEmpty(privacyPolicyStatus))
            {
                PrivacyPolicyStatus = privacyPolicyStatus;
            }

            if (publicComplaintsStatusScore != 0)
            {
                PublicComplaintsStatusScore = publicComplaintsStatusScore;
            }

            if (!string.IsNullOrEmpty(publicComplaintsStatus))
            {
                PublicComplaintsStatus = publicComplaintsStatus;
            }

            if (cyberAttackResponseStatusScore != 0)
            {
                CyberAttackResponseStatusScore = cyberAttackResponseStatusScore;
            }

            if (!string.IsNullOrEmpty(cyberAttackResponseStatus))
            {
                CyberAttackResponseStatus = cyberAttackResponseStatus;
            }

            if (dataSalesTradeStatusScore != 0)
            {
                DataSalesTradeStatusScore = dataSalesTradeStatusScore;
            }

            if (!string.IsNullOrEmpty(dataSalesTradeStatus))
            {
                DataSalesTradeStatus = dataSalesTradeStatus;
            }

            if (financialPaymentPlatformStatusScore != 0)
            {
                FinancialPaymentPlatformStatusScore = financialPaymentPlatformStatusScore;
            }

            if (!string.IsNullOrEmpty(financialPaymentPlatformStatus))
            {
                FinancialPaymentPlatformStatus = financialPaymentPlatformStatus;
            }

            if (userDataCollectionStatusScore != 0)
            {
                UserDataCollectionStatusScore = userDataCollectionStatusScore;
            }

            if (!string.IsNullOrEmpty(userDataCollectionStatus))
            {
                UserDataCollectionStatus = userDataCollectionStatus;
            }

            if (employeeTrainingStatusScore != 0)
            {
                EmployeeTrainingStatusScore = employeeTrainingStatusScore;
            }

            if (!string.IsNullOrEmpty(employeeTrainingStatus))
            {
                EmployeeTrainingStatus = employeeTrainingStatus;
            }

            AverageGeneral = averagegeneral;

           
        }



        public double AverageGeneralcal(EditChecklist command)
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

            var Avg = ((double)Sum / 38);
            var Average =   Math.Round(Avg,2);
            return Average;
        }

        

    }


}
