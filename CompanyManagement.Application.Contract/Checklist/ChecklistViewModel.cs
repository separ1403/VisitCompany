using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class ChecklistViewModel
    {
        public long Id { get; set; }
        public string Title { get;  set; }
//      public string Description { get;  set; }
        public string NamePeopleCo { get; set; } 
        public string RspponsePeopleCo { get; set; }
        public string PhonePeopleCo { get;  set; }
        public long? CountEmployees { get;  set; } 
        public long? CountFolowers { get;  set; }

        public long? CompanyId { get;  set; }
        public string Company { get; set; }
        public string CreattionDate { get; set; }
        public List<long>? AccountId { get;  set; }
        public string? Accounts { get; set; }

        public long AccountCount { get;  set; } // har nafar che tedad checklist anjam dade

        public double? AverageGeneral { get; set; }

        public double? AverageHpedl380 { get; set; }
        public double? AverageWin2019 { get; set; }
        public double? AverageJunipper { get; set; }
       
        public string? FinallDescriptionGeneral { get; set; }
        public string? FinallDescriptionHpedl380 { get; set; }
        public string? FinallDescriptionWin2019 { get; set; }
        public string? FinallDescriptionJunipper { get; set; }

        public double AverageProfessional { get; set; }// dar vaghe in ro bayad hazf mikardam am
        // chon safeheye chart mirikht be ham inkaro nakardam

        public DateTime CalDate { get; set; }
        

    }
}
