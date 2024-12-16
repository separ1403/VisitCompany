using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public  class GeneralProffesional:EntityBase
    {
        public string Name { get; private set; }
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
        public string? ClockSynchronizationStatus { get; private set; }// تا اینجا هم الزامات فنی

        //  ز اینجا به بعد مشترکات
        public double AverageGeneralProffesional { get; private set; }
        public Checklist Checklist { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند
        public string? FinallDescription { get; private set; }
        public string? UniqueCode { get; set; }




        public GeneralProffesional(long? networkLogicalPhysicalMapStatusScore, string? networkLogicalPhysicalMapStatus, long? physicalAssetsInventoryStatusScore, string? physicalAssetsInventoryStatus, long? zoningStatusScore, string? zoningStatus, long? accessControlStatusScore, string? accessControlStatus, long? developmentTestOperationsControlStatusScore, string? developmentTestOperationsControlStatus, long? remoteAdministrativeAccessStatusScore, string? remoteAdministrativeAccessStatus, long? secureCodingConfigStatusScore, string? secureCodingConfigStatus, long? securityEvaluationStatusScore, string? securityEvaluationStatus, long? backupStatusScore, string? backupStatus, long? sessionExpirationStatusScore, string? sessionExpirationStatus, long? antivirusStatusScore, string? antivirusStatus, long? updateStatusScore, string? updateStatus, long? wirelessNetworkStatusScore, string? wirelessNetworkStatus, long? passwordPolicyStatusScore, string? passwordPolicyStatus, long? dataDestructionStatusScore, string? dataDestructionStatus, long? logManagementStatusScore, string? logManagementStatus, long? clockSynchronizationStatusScore, string? clockSynchronizationStatus, string finallDescription)
        {
            Name = "چک لیست عمومی-فنی";
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
            IsCompleted = true;
            FinallDescription = finallDescription;
        }

        public GeneralProffesional()
        {


        }

        public void CalculateAverage(CreateCheckGenpro command)
        {
            var scores = new long?[]
            {
        command.NetworkLogicalPhysicalMapStatusScore,
        command.PhysicalAssetsInventoryStatusScore,
        command.ZoningStatusScore,
        command.AccessControlStatusScore,
        command.DevelopmentTestOperationsControlStatusScore,
        command.RemoteAdministrativeAccessStatusScore,
        command.SecureCodingConfigStatusScore,
        command.SecurityEvaluationStatusScore,
        command.BackupStatusScore,
        command.SessionExpirationStatusScore,
        command.AntivirusStatusScore,
        command.UpdateStatusScore,
        command.WirelessNetworkStatusScore,
        command.PasswordPolicyStatusScore,
        command.DataDestructionStatusScore,
        command.LogManagementStatusScore,
        command.ClockSynchronizationStatusScore
            };

            // جایگزینی null با 0 و محاسبه میانگین
            var average = scores.Select(score => score ?? 0).Average(); // مقادیر صفر و نال رو هم داخل میانگین محاسبه میکند
            AverageGeneralProffesional= average;
        }




    }
}
