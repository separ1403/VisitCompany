using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class GeneralPolicy:EntityBase
    {
        public string Name { get; private set; }

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
        public string? EmployeeTrainingStatus { get; private set; } // تا اینجا هم برای الزامات انتظامی

        //  ز اینجا به بعد مشترکات
        public double AverageGeneralPolicy { get; private set; }
        public Checklist Checklist { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند
        public string? FinallDescription { get; private set; }
        public string? UniqueCode { get; set; }


        public GeneralPolicy()
        {
        }

        public GeneralPolicy(long? authenticationStatusScore, string? authenticationStatus, long? businessIdentificationStatusScore, string? businessIdentificationStatus, long? entryExitManagementStatusScore, string? entryExitManagementStatus, long? cCTVStatusScore, string? cCTVStatus, long? hostingServiceStatusScore, string? hostingServiceStatus, long? privacyPolicyStatusScore, string? privacyPolicyStatus, long? publicComplaintsStatusScore, string? publicComplaintsStatus, long? cyberAttackResponseStatusScore, string? cyberAttackResponseStatus, long? dataSalesTradeStatusScore, string? dataSalesTradeStatus, long? financialPaymentPlatformStatusScore, string? financialPaymentPlatformStatus, long? userDataCollectionStatusScore, string? userDataCollectionStatus, long? employeeTrainingStatusScore, string? employeeTrainingStatus, string finallDescription)
        {
            Name = "چک لیست عمومی-انتظامی";

            AuthenticationStatusScore = authenticationStatusScore;
            AuthenticationStatus = authenticationStatus;
            BusinessIdentificationStatusScore = businessIdentificationStatusScore;
            BusinessIdentificationStatus = businessIdentificationStatus;
            EntryExitManagementStatusScore = entryExitManagementStatusScore;
            EntryExitManagementStatus = entryExitManagementStatus;
            CCTVStatusScore = cCTVStatusScore;
            CCTVStatus = cCTVStatus;
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
            IsCompleted = true;
            FinallDescription = finallDescription;

        }

            public void CalculateAverage(CreateCheckGenPol command)
        {
            var scores = new long?[]
            {
        command.AuthenticationStatusScore,
        command.BusinessIdentificationStatusScore,
        command.EntryExitManagementStatusScore,
        command.CCTVStatusScore,
        command.HostingServiceStatusScore,
        command.PrivacyPolicyStatusScore,
        command.PublicComplaintsStatusScore,
        command.CyberAttackResponseStatusScore,
        command.DataSalesTradeStatusScore,
        command.FinancialPaymentPlatformStatusScore,
        command.UserDataCollectionStatusScore,
        command.EmployeeTrainingStatusScore
            };

            // جایگزینی مقادیر null با 0 و محاسبه میانگین
            var average = scores.Select(score => score ?? 0).Average();
            AverageGeneralPolicy = average;
        }

    }
}

