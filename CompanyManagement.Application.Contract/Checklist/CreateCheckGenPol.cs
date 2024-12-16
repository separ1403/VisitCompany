using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class CreateCheckGenPol
    {

        public string Name { get; set; }

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
        public string FinallDescription { get; set; }

    }
}
