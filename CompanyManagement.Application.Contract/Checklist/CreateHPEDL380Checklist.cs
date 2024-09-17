using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateHPEDL380Checklist
    {
        public bool IsTPMEnabledAndRO { get; set; }
        public string IsTPMEnabledAndROdescription { get; set; }

        public bool AreAppropriateUsernamesCreated { get; set; }
        public string AreAppropriateUsernamesCreateddescription { get; set; }

        public bool AreAppropriateGroupsCreated { get; set; }
        public string AreAppropriateGroupsCreateddescription { get; set; }
        public bool AreNetworkSettingsForILOConfigured { get; set; }
        public string AreNetworkSettingsForILOConfigureddescription { get; set; }
        public bool AreInitialSettingsForILOConfigured { get; set; }
        public string AreInitialSettingsForILOConfigureddescription { get; set; }
        public bool IsServerNameAndFQDNSet { get; set; }
        public string IsServerNameAndFQDNSetdescription { get; set; }
        public bool IsAccountServiceConfigured { get; set; }
        public string IsAccountServiceConfigureddescription { get; set; }
        public bool AreILOPortAndUSBPortConfigured { get; set; }
        public string AreILOPortAndUSBPortConfigureddescription { get; set; }
        public bool AreSSHKeysEnabled { get; set; }
        public string AreSSHKeysEnableddescription { get; set; }

        public bool AreUserCertificatesConfigured { get; set; }
        public string AreUserCertificatesConfigureddescription { get; set; }

        public bool AreSystemCertificatesConfigured { get; set; }
        public string AreSystemCertificatesConfigureddescription { get; set; }
        public bool IsEncryptionConfigured { get; set; }
        public string IsEncryptionConfigureddescription { get; set; }

        public bool IsUEFISecurityConfigured { get; set; }
        public string IsUEFISecurityConfigureddescription { get; set; }

        public bool IsSecureBootConfigured { get; set; }
        public string IsSecureBootConfigureddescription { get; set; }

        public bool IsTPMConfigured { get; set; }
        public string IsTPMConfigureddescription { get; set; }

        public bool AreInitialILOSettingsConfigured { get; set; }
        public string AreInitialILOSettingsConfigureddescription { get; set; }

        public bool IsDiskAndRaidConfigDeletionDisabled { get; set; }
        public string IsDiskAndRaidConfigDeletionDisableddescription { get; set; }

        public bool AreProvisioningSettingsDeleted { get; set; }
        public string AreProvisioningSettingsDeleteddescription { get; set; }

        public long ChecklistId { get; set; }

    }
}
