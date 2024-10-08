using System;
using System.Collections.Generic;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class ChecklistViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? CountEmployees { get; set; }
        public long? CountFolowers { get; set; }

        public long? CompanyId { get; set; }
        public string Company { get; set; }
        public string CreattionDate { get; set; }

        public List<long>? AccountId { get; set; }
        public string? Accounts { get; set; }

        public long AccountCount { get; set; } // تعداد چک لیست‌های انجام‌شده توسط هر نفر

        public double? AverageGeneral { get; set; }
        public double? AverageHpedl380 { get; set; }
        public double? AverageWin2019 { get; set; }
        public double? AverageJunipper { get; set; }

        public string? FinallDescriptionGeneral { get; set; }
        public string? FinallDescriptionHpedl380 { get; set; }
        public string? FinallDescriptionWin2019 { get; set; }
        public string? FinallDescriptionJunipper { get; set; }

        // لیست افرادی که در این چک‌لیست حضور دارند
        public List<PersonViewModel> People { get; set; } = new List<PersonViewModel>();

        public DateTime CalDate { get; set; }
    }

    // ViewModel برای افراد موجود در چک‌لیست
    public class PersonViewModel
    {
        public string NamePeopleCo { get; set; }
        public string RspponsePeopleCo { get; set; }
        public string PhonePeopleCo { get; set; }
    }
}