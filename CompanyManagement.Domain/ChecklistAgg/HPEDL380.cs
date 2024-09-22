using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class HPEDL380:EntityBase
    {
        public HPEDL380(long isTpmEnabledAndRo, string isTpmEnabledAndROdescription, long areAppropriateUsernamesCreated, string areAppropriateUsernamesCreateddescription, long areAppropriateGroupsCreated, string areAppropriateGroupsCreateddescription, long areNetworkSettingsForIloConfigured, string areNetworkSettingsForIloConfigureddescription, long areInitialSettingsForIloConfigured, string areInitialSettingsForIloConfigureddescription, long isServerNameAndFqdnSet, string isServerNameAndFqdnSetdescription, long isAccountServiceConfigured, string isAccountServiceConfigureddescription, long areIloPortAndUsbPortConfigured, string areIloPortAndUsbPortConfigureddescription, long areSshKeysEnabled, string areSshKeysEnableddescription, long areUserCertificatesConfigured, string areUserCertificatesConfigureddescription, long areSystemCertificatesConfigured, string areSystemCertificatesConfigureddescription, long isEncryptionConfigured, string isEncryptionConfigureddescription, long isUefiSecurityConfigured, string isUefiSecurityConfigureddescription, long isSecureBootConfigured, string isSecureBootConfigureddescription, long isTpmConfigured, string isTpmConfigureddescription, long areInitialIloSettingsConfigured, string areInitialIloSettingsConfigureddescription, long isDiskAndRaidConfigDeletionDisabled, string isDiskAndRaidConfigDeletionDisableddescription, long areProvisioningSettingsDeleted, string areProvisioningSettingsDeleteddescription)
        {
            IsTPMEnabledAndRO = isTpmEnabledAndRo;
            IsTPMEnabledAndROdescription = isTpmEnabledAndROdescription;
            AreAppropriateUsernamesCreated = areAppropriateUsernamesCreated;
            AreAppropriateUsernamesCreateddescription = areAppropriateUsernamesCreateddescription;
            AreAppropriateGroupsCreated = areAppropriateGroupsCreated;
            AreAppropriateGroupsCreateddescription = areAppropriateGroupsCreateddescription;
            AreNetworkSettingsForILOConfigured = areNetworkSettingsForIloConfigured;
            AreNetworkSettingsForILOConfigureddescription = areNetworkSettingsForIloConfigureddescription;
            AreInitialSettingsForILOConfigured = areInitialSettingsForIloConfigured;
            AreInitialSettingsForILOConfigureddescription = areInitialSettingsForIloConfigureddescription;
            IsServerNameAndFQDNSet = isServerNameAndFqdnSet;
            IsServerNameAndFQDNSetdescription = isServerNameAndFqdnSetdescription;
            IsAccountServiceConfigured = isAccountServiceConfigured;
            IsAccountServiceConfigureddescription = isAccountServiceConfigureddescription;
            AreILOPortAndUSBPortConfigured = areIloPortAndUsbPortConfigured;
            AreILOPortAndUSBPortConfigureddescription = areIloPortAndUsbPortConfigureddescription;
            AreSSHKeysEnabled = areSshKeysEnabled;
            AreSSHKeysEnableddescription = areSshKeysEnableddescription;
            AreUserCertificatesConfigured = areUserCertificatesConfigured;
            AreUserCertificatesConfigureddescription = areUserCertificatesConfigureddescription;
            AreSystemCertificatesConfigured = areSystemCertificatesConfigured;
            AreSystemCertificatesConfigureddescription = areSystemCertificatesConfigureddescription;
            IsEncryptionConfigured = isEncryptionConfigured;
            IsEncryptionConfigureddescription = isEncryptionConfigureddescription;
            IsUEFISecurityConfigured = isUefiSecurityConfigured;
            IsUEFISecurityConfigureddescription = isUefiSecurityConfigureddescription;
            IsSecureBootConfigured = isSecureBootConfigured;
            IsSecureBootConfigureddescription = isSecureBootConfigureddescription;
            IsTPMConfigured = isTpmConfigured;
            IsTPMConfigureddescription = isTpmConfigureddescription;
            AreInitialILOSettingsConfigured = areInitialIloSettingsConfigured;
            AreInitialILOSettingsConfigureddescription = areInitialIloSettingsConfigureddescription;
            IsDiskAndRaidConfigDeletionDisabled = isDiskAndRaidConfigDeletionDisabled;
            IsDiskAndRaidConfigDeletionDisableddescription = isDiskAndRaidConfigDeletionDisableddescription;
            AreProvisioningSettingsDeleted = areProvisioningSettingsDeleted;
            AreProvisioningSettingsDeleteddescription = areProvisioningSettingsDeleteddescription;
         //   AverageHpedl380 = averageHpedl380;

        }


        public HPEDL380()
        {

        }

        public long? IsTPMEnabledAndRO { get; set; }
        public string? IsTPMEnabledAndROdescription { get; set; }

        public long? AreAppropriateUsernamesCreated { get; set; }
        public string? AreAppropriateUsernamesCreateddescription { get; set; }

        public long? AreAppropriateGroupsCreated { get; set; }
        public string? AreAppropriateGroupsCreateddescription { get; set; }
        public long? AreNetworkSettingsForILOConfigured { get; set; }
        public string? AreNetworkSettingsForILOConfigureddescription { get; set; }
        public long? AreInitialSettingsForILOConfigured { get; set; }
        public string? AreInitialSettingsForILOConfigureddescription  { get; set; }
        public long? IsServerNameAndFQDNSet { get; set; }
        public string? IsServerNameAndFQDNSetdescription  { get; set; }
        public long? IsAccountServiceConfigured { get; set; }
        public string? IsAccountServiceConfigureddescription { get; set; }
        public long? AreILOPortAndUSBPortConfigured { get; set; }
        public string? AreILOPortAndUSBPortConfigureddescription { get; set; }
        public long? AreSSHKeysEnabled { get; set; }
        public string? AreSSHKeysEnableddescription { get; set; }

        public long? AreUserCertificatesConfigured { get; set; }
        public string? AreUserCertificatesConfigureddescription { get; set; }

        public long? AreSystemCertificatesConfigured { get; set; }
        public string? AreSystemCertificatesConfigureddescription  { get; set; }
        public long? IsEncryptionConfigured { get; set; }
        public string? IsEncryptionConfigureddescription  { get; set; }

       public long? IsUEFISecurityConfigured { get; set; }
       public string? IsUEFISecurityConfigureddescription { get; set; }

       public long? IsSecureBootConfigured { get; set; }
       public string? IsSecureBootConfigureddescription { get; set; }

      public long? IsTPMConfigured { get; set; }
      public string? IsTPMConfigureddescription { get; set; }

      public long? AreInitialILOSettingsConfigured { get; set; }
      public string? AreInitialILOSettingsConfigureddescription { get; set; }

      public long? IsDiskAndRaidConfigDeletionDisabled { get; set; }
      public string? IsDiskAndRaidConfigDeletionDisableddescription { get; set; }

      public long? AreProvisioningSettingsDeleted { get; set; }
      public string? AreProvisioningSettingsDeleteddescription  { get; set; }

      public double AverageHpedl380 { get; private set; }
        public Checklist Checklist { get; set; }


        public void AverageHPEDLcal(CreateHPEDL380Checklist command)
        {
            IsTPMEnabledAndRO ??= 0;
            AreAppropriateUsernamesCreated ??= 0;
            AreAppropriateGroupsCreated ??= 0;
            AreNetworkSettingsForILOConfigured ??= 0;
            AreInitialSettingsForILOConfigured ??= 0;
            IsServerNameAndFQDNSet ??= 0;
            IsAccountServiceConfigured ??= 0;
            AreILOPortAndUSBPortConfigured ??= 0;
            AreSSHKeysEnabled ??= 0;
            AreUserCertificatesConfigured ??= 0;
            AreSystemCertificatesConfigured ??= 0;
            IsEncryptionConfigured ??= 0;
            IsUEFISecurityConfigured ??= 0;
            IsSecureBootConfigured ??= 0;
            IsTPMConfigured ??= 0;
            AreInitialILOSettingsConfigured ??= 0;
            IsDiskAndRaidConfigDeletionDisabled ??= 0;
            AreProvisioningSettingsDeleted ??= 0;

            var Sum = command.IsTPMEnabledAndRO + command.AreAppropriateUsernamesCreated +
                      command.AreAppropriateGroupsCreated +
                      command.AreNetworkSettingsForILOConfigured + command.AreInitialSettingsForILOConfigured +
                      command.IsServerNameAndFQDNSet
                      + command.IsAccountServiceConfigured + command.AreILOPortAndUSBPortConfigured +
                      command.AreSSHKeysEnabled +
                      command.AreUserCertificatesConfigured + command.AreSystemCertificatesConfigured +
                      command.IsEncryptionConfigured +
                      command.IsUEFISecurityConfigured + command.IsSecureBootConfigured + command.IsTPMConfigured +
                      command.AreInitialILOSettingsConfigured
                      + command.IsDiskAndRaidConfigDeletionDisabled + command.AreProvisioningSettingsDeleted;
            var Avg = ((double)Sum / 18);
            var Average = Math.Round(Avg, 2);
            AverageHpedl380 = Average;
        }
    }
    }



   
