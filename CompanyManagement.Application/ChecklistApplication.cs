using Azure;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using Framework.Application;

namespace CompanyManagement.Application
{
    public class ChecklistApplication : IChecklistApplication
    {
        public ChecklistApplication(IChecklistRepository checklistRepository, IjuniperhardeningRepository junuperhardeningRepository, IHPEDL380Repository hPedl380Repository, IWin2019Repository win2019Repository)
        {
            _checklistRepository = checklistRepository;
            _junuperhardeningRepository = junuperhardeningRepository;
            _hPEDL380Repository = hPedl380Repository;
            _win2019Repository = win2019Repository;
        }


        private readonly IChecklistRepository _checklistRepository;
        private readonly IjuniperhardeningRepository _junuperhardeningRepository;
        private readonly IHPEDL380Repository _hPEDL380Repository;
        private readonly IWin2019Repository _win2019Repository;
       


        public OperationResult  Create(CreateChecklist command)
        {
            var LastVisitTime = _checklistRepository.GetLastCompanyDate();//آخرین رکورد تاریخ رو بر میگردونه
            var operation = new OperationResult();
            if (_checklistRepository.Exists(x => x.CompanyId == command.CompanyId && LastVisitTime <= DateTime.Now.AddMonths(-3)))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }
            var checkList = new Checklist(
     command.Title, command.Description, command.NamePeopleCo, command.RspponsePeopleCo, command.PhonePeopleCo,
     command.CountEmployees, command.CountFolowers, command.CompanyId, command.AccountIds, command.OrganizationalSecurityStatusScore,
     command.OrganizationalSecurityStatus, command.SecurityManagerStatusScore, command.SecurityManagerStatus,
     command.SecurityPolicyStatusScore, command.SecurityPolicyStatus, command.SecurityChangeApprovalStatusScore,
     command.SecurityChangeApprovalStatus, command.ThirdPartyServiceStatusScore, command.ThirdPartyServiceStatus,
     command.PersonnelHiringStatusScore, command.PersonnelHiringStatus, command.AccessManagementStatusScore,
     command.AccessManagementStatus, command.ComplianceManagementStatusScore, command.ComplianceManagementStatus,
     command.IncidentResponseStatusScore, command.IncidentResponseStatus, command.NetworkLogicalPhysicalMapStatusScore,
     command.NetworkLogicalPhysicalMapStatus, command.PhysicalAssetsInventoryStatusScore, command.PhysicalAssetsInventoryStatus,
     command.ZoningStatusScore, command.ZoningStatus, command.AccessControlStatusScore, command.AccessControlStatus,
     command.DevelopmentTestOperationsControlStatusScore, command.DevelopmentTestOperationsControlStatus,
     command.RemoteAdministrativeAccessStatusScore, command.RemoteAdministrativeAccessStatus, command.SecureCodingConfigStatusScore,
     command.SecureCodingConfigStatus, command.SecurityEvaluationStatusScore, command.SecurityEvaluationStatus,
     command.BackupStatusScore, command.BackupStatus, command.SessionExpirationStatusScore, command.SessionExpirationStatus,
     command.AntivirusStatusScore, command.AntivirusStatus, command.UpdateStatusScore, command.UpdateStatus,
     command.WirelessNetworkStatusScore, command.WirelessNetworkStatus, command.PasswordPolicyStatusScore,
     command.PasswordPolicyStatus, command.DataDestructionStatusScore, command.DataDestructionStatus,
     command.LogManagementStatusScore, command.LogManagementStatus, command.ClockSynchronizationStatusScore,
     command.ClockSynchronizationStatus, command.AuthenticationStatusScore, command.AuthenticationStatus,
     command.BusinessIdentificationStatusScore, command.BusinessIdentificationStatus, command.EntryExitManagementStatusScore,
     command.EntryExitManagementStatus, command.CCTVStatusScore, command.CCTVStatus, command.HostingServiceStatusScore,
     command.HostingServiceStatus, command.PrivacyPolicyStatusScore, command.PrivacyPolicyStatus,
     command.PublicComplaintsStatusScore, command.PublicComplaintsStatus, command.CyberAttackResponseStatusScore,
     command.CyberAttackResponseStatus, command.DataSalesTradeStatusScore, command.DataSalesTradeStatus,
     command.FinancialPaymentPlatformStatusScore, command.FinancialPaymentPlatformStatus, command.UserDataCollectionStatusScore,
     command.UserDataCollectionStatus, command.EmployeeTrainingStatusScore, command.EmployeeTrainingStatus
     /*,command.JuniperHardeningID, command.HPEDL380ID*/);

            _checklistRepository.Create(checkList);
            _checklistRepository.SaveChanges();
            var lastCompanyId = checkList.Id; // گرفتن شناسه رکورد جدید
            return operation.Succeeded("عملیات با موفقیت انجام گردید", lastCompanyId);
        }

        public OperationResult CreateJuniper(CreateJuniperChecklist command)
        {
           
            var operation = new OperationResult();
           
            var checkListJuniperHardenin = new JuniperHardening(command.IsConsolePortSecured,command.IsConsolePortSecureddescription,
                command.IsRootLoginDisabled, command.IsRootLoginDisableddescription, command.IsPasswordRecoveryDisabled, 
                command.IsPasswordRecoveryDisableddescription,
                command.IsAuxiliaryPortDisabled, command.IsAuxiliaryPortDisableddescription, 
                command.IsRootLoginAuxDisabled, command.IsRootLoginAuxDisableddescription, 
                command.IsDiagnosticPortDisabled, command.IsDiagnosticPortDisableddescription,
                command.IsUSBPortDisabled, command.IsUSBPortDisableddescription,
                command.IsCraftInterfaceDisabled, command.IsCraftInterfaceDisableddescription,
                command.IsLCDMenuDisabled, command.IsLCDMenuDisableddescription,
                command.IsResetButtonDisabled, command.IsResetButtonDisableddescription,
                command.AreUnusedInterfacesDisabled, command.AreUnusedInterfacesDisableddescription,
                command.IsConfigFileEncrypted, command.IsConfigFileEncrypteddescription);

            _junuperhardeningRepository.Create(checkListJuniperHardenin);
            _checklistRepository.SaveChanges();
            var currentId = checkListJuniperHardenin.Id; // گرفتن شناسه رکورد جدید
           
            return operation.Succeeded("عملیات با موفقیت انجام گردید", currentId);
        }

        public OperationResult CreateHPEDL380(CreateHPEDL380Checklist command)
        {
            
            var operation = new OperationResult();



            var checkListHPEDL380 = new HPEDL380(command.IsTPMEnabledAndRO,command.IsTPMEnabledAndROdescription, command.AreAppropriateUsernamesCreated,
                command.AreAppropriateUsernamesCreateddescription,
                command.AreAppropriateGroupsCreated,command.AreAppropriateGroupsCreateddescription,command.AreNetworkSettingsForILOConfigured,
                command.AreNetworkSettingsForILOConfigureddescription,
                command.AreInitialSettingsForILOConfigured,command.AreInitialSettingsForILOConfigureddescription,
                command.IsServerNameAndFQDNSet,command.IsServerNameAndFQDNSetdescription,command.IsAccountServiceConfigured,
                command.IsAccountServiceConfigureddescription, command.AreILOPortAndUSBPortConfigured,
                command.AreILOPortAndUSBPortConfigureddescription,command.AreSSHKeysEnabled, 
                command.AreSSHKeysEnableddescription,command.AreUserCertificatesConfigured,
                command.AreUserCertificatesConfigureddescription,command.AreSystemCertificatesConfigured,
                command.AreSystemCertificatesConfigureddescription,command.IsEncryptionConfigured,
                command.IsEncryptionConfigureddescription,command.IsUEFISecurityConfigured,
                command.IsUEFISecurityConfigureddescription,command.IsSecureBootConfigured,
                command.IsSecureBootConfigureddescription,command.IsTPMConfigured,command.IsTPMConfigureddescription
                ,command.AreInitialILOSettingsConfigured,
                command.AreInitialILOSettingsConfigureddescription,command.IsDiskAndRaidConfigDeletionDisabled
                ,command.IsDiskAndRaidConfigDeletionDisableddescription,command.AreProvisioningSettingsDeleted,
                command.AreProvisioningSettingsDeleteddescription);


            checkListHPEDL380.AverageHPEDLcal(command);



            _hPEDL380Repository.Create(checkListHPEDL380);
            _checklistRepository.SaveChanges();
            var currentId = checkListHPEDL380.Id; // گرفتن شناسه رکورد جدید

            return operation.Succeeded("عملیات با موفقیت انجام گردید", currentId);
        }

        public OperationResult CreateWin2019(CreateWin2019Checklist command)
        {

            var operation = new OperationResult();

            var checkListWin2019 = new Win2019(command.IsPasswordHistoryEnabled, command.IsPasswordHistoryEnabledDescription,
                command.IsMaxPasswordAgeConfigured, command.IsMaxPasswordAgeConfiguredDescription, command.IsMinPasswordAgeConfigured
                , command.IsMinPasswordAgeConfiguredDescription, command.IsMinPasswordLengthConfigured, command.IsMinPasswordLengthConfiguredDescription,
                command.IsComplexPasswordRequired, command.IsComplexPasswordRequiredDescription, command.IsPlainTextPasswordStorageDisabled,
              command.IsPlainTextPasswordStorageDisabledDescription, command.IsAccountLockoutDurationConfigured, command.IsAccountLockoutDurationConfiguredDescription,
              command.IsFailedLogonAttemptsLimited, command.IsFailedLogonAttemptsLimitedDescription,
              command.IsAdminLockoutConfigured, command.IsAdminLockoutConfiguredDescription, command.IsPasswordResetErrorCountConfigured,
              command.IsPasswordResetErrorCountConfiguredDescription, command.IsUserAccountManagementRestricted,
              command.IsUserAccountManagementRestrictedDescription, command.IsRemoteAccessManaged, command.IsRemoteAccessManagedDescription,
           command.IsOSAccountAccessLimited, command.IsOSAccountAccessLimitedDescription, command.IsDomainJoinRestricted,
           command.IsDomainJoinRestrictedDescription, command.IsMemoryManagementPermissionGranted, command.IsMemoryManagementPermissionGrantedDescription
           , command.IsLocalConsoleLogonRestricted, command.IsLocalConsoleLogonRestrictedDescription, command.IsRemoteLogonGroupManaged, command.IsRemoteLogonGroupManagedDescription
           , command.IsBackupAccessManaged, command.IsBackupAccessManagedDescription, command.IsSystemTimeChangeManaged,
           command.IsSystemTimeChangeManagedDescription, command.IsAccessTokenCreationLimited, command.IsAccessTokenCreationLimitedDescription
           , command.IsRemoteLogonRestrictedForGuests, command.IsRemoteLogonRestrictedForGuestsDescription, command.IsScheduledTasksPermissionManaged,
           command.IsScheduledTasksPermissionManagedDescription, command.IsLogonAsServicePermissionManaged, command.IsLogonAsServicePermissionManagedDescription,
           command.IsGuestLogonManaged, command.IsGuestLogonManagedDescription, command.IsLocalAccountLogonManaged,
           command.IsLocalAccountLogonManagedDescription, command.IsLogonAsServiceSettingsApplied, command.IsLogonAsServiceSettingsAppliedDescription,
           command.IsRemoteShutdownPermissionManaged, command.IsRemoteShutdownPermissionManagedDescription, command.IsAdministratorUsernameChanged,
           command.IsAdministratorUsernameChangedDescription, command.IsCachedUsernameCountManaged, command.IsCachedUsernameCountManagedDescription,
           command.IsPasswordExpirationWarningManaged, command.IsPasswordExpirationWarningManagedDescription, command.IsAnonymousSIDRequestManaged,
           command.IsAnonymousSIDRequestManagedDescription, command.IsNTFSMediaAccessManaged, command.IsNTFSMediaAccessManagedDescription,
           command.IsSharedPrinterDriverInstallationManaged, command.IsSharedPrinterDriverInstallationManagedDescription, command.IsPrinterSpoolerServiceManaged,
           command.IsPrinterSpoolerServiceManagedDescription, command.IsOnlineTipManaged, command.IsOnlineTipManagedDescription,
           command.IsKeepAliveTimeManaged, command.IsKeepAliveTimeManagedDescription, command.IsIRDPOptionDisabled,
           command.IsIRDPOptionDisabledDescription, command.IsDataRetransmissionManaged, command.IsDataRetransmissionManagedDescription
          );
            checkListWin2019.AverageWin2019cal(command);
            _win2019Repository.Create(checkListWin2019);
            _checklistRepository.SaveChanges();
            var currentId = checkListWin2019.Id; // گرفتن شناسه رکورد جدید

            return operation.Succeeded("عملیات با موفقیت انجام گردید", currentId);
        }


        public OperationResult EditJunior(long id, long chekid)
        {
            var operation = new OperationResult();
            var checklist = _checklistRepository.Get(chekid);

            if (checklist == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }
            


            checklist.Editjunior(id);
            _checklistRepository.SaveChanges();
            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }




        public OperationResult EditHPEDL380(long id, long chekid)
        {
            var operation = new OperationResult();
            var checklist = _checklistRepository.Get(chekid);

            if (checklist == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }
            


            checklist.EditHPEDL380(id);
            _checklistRepository.SaveChanges();
            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }


        public OperationResult EditWin2019(long id, long chekid)
        {
            var operation = new OperationResult();
            var checklist = _checklistRepository.Get(chekid);

            if (checklist == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }



            checklist.EditWin2019(id);
            _checklistRepository.SaveChanges();
            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public OperationResult Edit(EditChecklist command, string sourcePage)
        {
            var operation = new OperationResult();
            var checklist = _checklistRepository.Get(command.Id);

            if (checklist == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }
            if (sourcePage == "Confirm") // baraye inke az kodom safhe request amade
            {
                command.AverageGeneral = _checklistRepository.AverageGeneralcal(command);

            }

            //if (sourcePage == "Create2") // baraye inke az kodom safhe request amade
            //{
            //    command.AverageProfesional = _checklistRepository.AverageProffcal(command);
            //}


            checklist.Edit(command.OrganizationalSecurityStatusScore,
                command.OrganizationalSecurityStatus, command.SecurityManagerStatusScore, command.SecurityManagerStatus,command.SecurityPolicyStatusScore,
                command.SecurityPolicyStatus, command.SecurityChangeApprovalStatusScore,
                command.SecurityChangeApprovalStatus, command.ThirdPartyServiceStatusScore, command.ThirdPartyServiceStatus, command.PersonnelHiringStatusScore,
                command.PersonnelHiringStatus, command.AccessManagementStatusScore, command.AccessManagementStatus, command.ComplianceManagementStatusScore,
                command.ComplianceManagementStatus, command.IncidentResponseStatusScore, command.IncidentResponseStatus, command.NetworkLogicalPhysicalMapStatusScore,
                command.NetworkLogicalPhysicalMapStatus, command.PhysicalAssetsInventoryStatusScore, command.PhysicalAssetsInventoryStatus, command.ZoningStatusScore,
                command.ZoningStatus, command.AccessControlStatusScore, command.AccessControlStatus, command.DevelopmentTestOperationsControlStatusScore,
                command.DevelopmentTestOperationsControlStatus, command.RemoteAdministrativeAccessStatusScore, command.RemoteAdministrativeAccessStatus,
                command.SecureCodingConfigStatusScore, command.SecureCodingConfigStatus, command.SecurityEvaluationStatusScore, command.SecurityEvaluationStatus,
                command.BackupStatusScore, command.BackupStatus, command.SessionExpirationStatusScore, command.SessionExpirationStatus, command.AntivirusStatusScore,
                command.AntivirusStatus, command.UpdateStatusScore, command.UpdateStatus, command.WirelessNetworkStatusScore, command.WirelessNetworkStatus,
                command.PasswordPolicyStatusScore, command.PasswordPolicyStatus, command.DataDestructionStatusScore, command.DataDestructionStatus,
                command.LogManagementStatusScore, command.LogManagementStatus, command.ClockSynchronizationStatusScore, command.ClockSynchronizationStatus,
                command.AuthenticationStatusScore, command.AuthenticationStatus, command.BusinessIdentificationStatusScore, command.BusinessIdentificationStatus,
                command.EntryExitManagementStatusScore, command.EntryExitManagementStatus, command.CCTVStatusScore, command.CCTVStatus, command.HostingServiceStatusScore,
                command.HostingServiceStatus, command.PrivacyPolicyStatusScore, command.PrivacyPolicyStatus, command.PublicComplaintsStatusScore,
                command.PublicComplaintsStatus, command.CyberAttackResponseStatusScore, command.CyberAttackResponseStatus, command.DataSalesTradeStatusScore,
                command.DataSalesTradeStatus, command.FinancialPaymentPlatformStatusScore, command.FinancialPaymentPlatformStatus, command.UserDataCollectionStatusScore,
                command.UserDataCollectionStatus, command.EmployeeTrainingStatusScore, command.EmployeeTrainingStatus,command.AverageGeneral);
            _checklistRepository.SaveChanges();
            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }



        public List<ChecklistViewModel> GetChecklists()
        {
            return _checklistRepository.GetChecklists();
        }
        public EditChecklist Getdetails(long id)
        {
            return _checklistRepository.Getdetails(id);
        }

        public List<ChecklistViewModel> Serach(ChecklistSearchModel searchModel)
        {
            return _checklistRepository.Serach(searchModel);
        }

        //public long GetLastCompanyId()
        //{
        //    return _checklistRepository.GetLastCompanyId();
        //}

      

        public List<ChecklistViewModel> GetAverageGeneralByCompany(ChecklistSearchModel searchModel)
        {
            return _checklistRepository.GetAverageGeneralByCompany( searchModel);
        }

        public List<ChecklistViewModel> GetAverageGeneralByCompareCompany(ChecklistSearchModel2 searchModel2)
        {
            return _checklistRepository.GetAverageGeneralByCompareCompany(searchModel2);
        }

        public List<ChecklistViewModel> GetAverageProffesionalByCompany(ChecklistSearchModel searchModel)
        {
            return _checklistRepository.GetAverageProffesionalByCompany(searchModel);
        }

        public List<ChecklistViewModel> SerachByAccount(long accountId)
        {
            return _checklistRepository.SerachByAccount(accountId);
        }

       
    }
}
