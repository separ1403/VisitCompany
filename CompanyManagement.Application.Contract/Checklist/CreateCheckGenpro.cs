using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
   public  class CreateCheckGenpro
    {
        public string Name { get; set; }
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
       
        public double AverageGeneralProffesional { get; set; }
        public long ChecklistId { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند
        public string FinallDescription { get; set; }




    }
}
