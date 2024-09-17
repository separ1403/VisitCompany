using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class HPEDL380:EntityBase
    {
        public HPEDL380(bool isTpmEnabledAndRo, string isTpmEnabledAndROdescription, bool areAppropriateUsernamesCreated, string areAppropriateUsernamesCreateddescription, bool areAppropriateGroupsCreated, string areAppropriateGroupsCreateddescription, bool areNetworkSettingsForIloConfigured, string areNetworkSettingsForIloConfigureddescription, bool areInitialSettingsForIloConfigured, string areInitialSettingsForIloConfigureddescription, bool isServerNameAndFqdnSet, string isServerNameAndFqdnSetdescription, bool isAccountServiceConfigured, string isAccountServiceConfigureddescription, bool areIloPortAndUsbPortConfigured, string areIloPortAndUsbPortConfigureddescription, bool areSshKeysEnabled, string areSshKeysEnableddescription, bool areUserCertificatesConfigured, string areUserCertificatesConfigureddescription, bool areSystemCertificatesConfigured, string areSystemCertificatesConfigureddescription, bool isEncryptionConfigured, string isEncryptionConfigureddescription, bool isUefiSecurityConfigured, string isUefiSecurityConfigureddescription, bool isSecureBootConfigured, string isSecureBootConfigureddescription, bool isTpmConfigured, string isTpmConfigureddescription, bool areInitialIloSettingsConfigured, string areInitialIloSettingsConfigureddescription, bool isDiskAndRaidConfigDeletionDisabled, string isDiskAndRaidConfigDeletionDisableddescription, bool areProvisioningSettingsDeleted, string areProvisioningSettingsDeleteddescription)
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
        }


        public HPEDL380()
        {

        }

        public bool? IsTPMEnabledAndRO { get; set; }
        public string? IsTPMEnabledAndROdescription { get; set; }

        public bool? AreAppropriateUsernamesCreated { get; set; }
        public string? AreAppropriateUsernamesCreateddescription { get; set; }

        public bool? AreAppropriateGroupsCreated { get; set; }
        public string? AreAppropriateGroupsCreateddescription { get; set; }
        public bool? AreNetworkSettingsForILOConfigured { get; set; }
        public string? AreNetworkSettingsForILOConfigureddescription { get; set; }
        public bool? AreInitialSettingsForILOConfigured { get; set; }
        public string? AreInitialSettingsForILOConfigureddescription  { get; set; }
        public bool? IsServerNameAndFQDNSet { get; set; }
        public string? IsServerNameAndFQDNSetdescription  { get; set; }
        public bool? IsAccountServiceConfigured { get; set; }
        public string? IsAccountServiceConfigureddescription { get; set; }
        public bool? AreILOPortAndUSBPortConfigured { get; set; }
        public string? AreILOPortAndUSBPortConfigureddescription { get; set; }
        public bool? AreSSHKeysEnabled { get; set; }
        public string? AreSSHKeysEnableddescription { get; set; }

        public bool? AreUserCertificatesConfigured { get; set; }
        public string? AreUserCertificatesConfigureddescription { get; set; }

        public bool? AreSystemCertificatesConfigured { get; set; }
        public string? AreSystemCertificatesConfigureddescription  { get; set; }
        public bool? IsEncryptionConfigured { get; set; }
        public string? IsEncryptionConfigureddescription  { get; set; }

       public bool? IsUEFISecurityConfigured { get; set; }
       public string? IsUEFISecurityConfigureddescription { get; set; }

       public bool? IsSecureBootConfigured { get; set; }
       public string? IsSecureBootConfigureddescription { get; set; }

      public bool? IsTPMConfigured { get; set; }
      public string? IsTPMConfigureddescription { get; set; }

      public bool? AreInitialILOSettingsConfigured { get; set; }
      public string? AreInitialILOSettingsConfigureddescription { get; set; }

      public bool? IsDiskAndRaidConfigDeletionDisabled { get; set; }
      public string? IsDiskAndRaidConfigDeletionDisableddescription { get; set; }

      public bool? AreProvisioningSettingsDeleted { get; set; }
      public string? AreProvisioningSettingsDeleteddescription  { get; set; }
      public Checklist Checklist { get; set; }
    }
}
