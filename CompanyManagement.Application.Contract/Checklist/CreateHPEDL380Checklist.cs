using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateHPEDL380Checklist
    {
        public long IsTPMEnabledAndRO { get; set; }
        public string IsTPMEnabledAndROdescription { get; set; }

        public long AreAppropriateUsernamesCreated { get; set; }
        public string AreAppropriateUsernamesCreateddescription { get; set; }

        public long AreAppropriateGroupsCreated { get; set; }
        public string AreAppropriateGroupsCreateddescription { get; set; }
        public long AreNetworkSettingsForILOConfigured { get; set; }
        public string AreNetworkSettingsForILOConfigureddescription { get; set; }
        public long AreInitialSettingsForILOConfigured { get; set; }
        public string AreInitialSettingsForILOConfigureddescription { get; set; }
        public long IsServerNameAndFQDNSet { get; set; }
        public string IsServerNameAndFQDNSetdescription { get; set; }
        public long IsAccountServiceConfigured { get; set; }
        public string IsAccountServiceConfigureddescription { get; set; }
        public long AreILOPortAndUSBPortConfigured { get; set; }
        public string AreILOPortAndUSBPortConfigureddescription { get; set; }
        public long AreSSHKeysEnabled { get; set; }
        public string AreSSHKeysEnableddescription { get; set; }

        public long AreUserCertificatesConfigured { get; set; }
        public string AreUserCertificatesConfigureddescription { get; set; }

        public long AreSystemCertificatesConfigured { get; set; }
        public string AreSystemCertificatesConfigureddescription { get; set; }
        public long IsEncryptionConfigured { get; set; }
        public string IsEncryptionConfigureddescription { get; set; }

        public long IsUEFISecurityConfigured { get; set; }
        public string IsUEFISecurityConfigureddescription { get; set; }

        public long IsSecureBootConfigured { get; set; }
        public string IsSecureBootConfigureddescription { get; set; }

        public long IsTPMConfigured { get; set; }
        public string IsTPMConfigureddescription { get; set; }

        public long AreInitialILOSettingsConfigured { get; set; }
        public string AreInitialILOSettingsConfigureddescription { get; set; }

        public long IsDiskAndRaidConfigDeletionDisabled { get; set; }
        public string IsDiskAndRaidConfigDeletionDisableddescription { get; set; }

        public long AreProvisioningSettingsDeleted { get; set; }
        public string AreProvisioningSettingsDeleteddescription { get; set; }
        public double AverageHpedl380 { get;  set; }

        public long ChecklistId { get; set; }

    }
}
