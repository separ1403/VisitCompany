using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
  

    public class GeneralChecklistRepository : RepositoryBase<long, GeneralChecklist>, IGeneralChecklistRepository
    {



        public GeneralChecklistRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


      

        public EditGeneralChecklist Getdetails(long id)
        {
            return _companyContext.GeneralChecklists.Select(x => new EditGeneralChecklist()
            {
                Id = x.Id,
                // AccountIds = x.AccountId,
                //CompanyId = x.CompanyId ?? 0,
                //Description = x.Description,
                IsCompleted = x.IsCompleted,
                Name = "چک لیست عمومی",


            }).FirstOrDefault(x => x.Id == id);
        }

        // توضیحات مربوط به ریفلکشن  خوانده شود 
        // این متد تمام نمرات هر ستون در جدول مروبطه در دیتابیس رو جمع میزنه و هرکدوم که نمرات کمتری دارند و نمایش میده
        // برای پیدا کردن آیتمی که بیشترین نقطه ضعف در بین سایر ایتم ها  است به کار کیره

        public List<(string PropertyName, long TotalScore)> GetMostVulnerableProperties()
        {
            var result = new List<(string PropertyName, long TotalScore)>();

            // دیکشنری برای نگه‌داری نام‌های دلخواه
            var columnDisplayNames = new Dictionary<string, string>
    {
        { nameof(GeneralChecklist.OrganizationalSecurityStatusScore), "وضعیت امنیت سازمانی" },
        { nameof(GeneralChecklist.SecurityManagerStatusScore), "وضعیت مدیر امنیت" },
        { nameof(GeneralChecklist.SecurityPolicyStatusScore), "وضعیت سیاست امنیتی" },
        { nameof(GeneralChecklist.SecurityChangeApprovalStatusScore), "وضعیت تایید تغییرات امنیتی" },
        { nameof(GeneralChecklist.ThirdPartyServiceStatusScore), "وضعیت خدمات شخص ثالث" },
        { nameof(GeneralChecklist.PersonnelHiringStatusScore), "وضعیت استخدام پرسنل" },
        { nameof(GeneralChecklist.AccessManagementStatusScore), "وضعیت مدیریت دسترسی" },
        { nameof(GeneralChecklist.ComplianceManagementStatusScore), "وضعیت مدیریت انطباق" },
        { nameof(GeneralChecklist.IncidentResponseStatusScore), "وضعیت پاسخ به حوادث" },

        { nameof(GeneralPolicy.AuthenticationStatusScore), "وضعیت احراز هویت" },
        { nameof(GeneralPolicy.BusinessIdentificationStatusScore), "وضعیت شناسایی کسب‌وکار" },
        { nameof(GeneralPolicy.EntryExitManagementStatusScore), "وضعیت مدیریت ورود و خروج" },
        { nameof(GeneralPolicy.CCTVStatusScore), "وضعیت دوربین مداربسته" },
        { nameof(GeneralPolicy.HostingServiceStatusScore), "وضعیت خدمات میزبانی" },
        { nameof(GeneralPolicy.PrivacyPolicyStatusScore), "وضعیت سیاست حریم خصوصی" },
        { nameof(GeneralPolicy.PublicComplaintsStatusScore), "وضعیت شکایات عمومی" },
        { nameof(GeneralPolicy.CyberAttackResponseStatusScore), "وضعیت پاسخ به حملات سایبری" },
        { nameof(GeneralPolicy.DataSalesTradeStatusScore), "وضعیت فروش و تجارت داده" },

        { nameof(GeneralProffesional.NetworkLogicalPhysicalMapStatusScore), "نقشه منطقی-فیزیکی شبکه" },
        { nameof(GeneralProffesional.PhysicalAssetsInventoryStatusScore), "موجودی دارایی‌های فیزیکی" },
        { nameof(GeneralProffesional.ZoningStatusScore), "وضعیت منطقه‌بندی" },
        { nameof(GeneralProffesional.AccessControlStatusScore), "کنترل دسترسی" },
        { nameof(GeneralProffesional.DevelopmentTestOperationsControlStatusScore), "کنترل توسعه، تست و عملیات" },
        { nameof(GeneralProffesional.RemoteAdministrativeAccessStatusScore), "دسترسی مدیریت از راه دور" },
        { nameof(GeneralProffesional.SecureCodingConfigStatusScore), "پیکربندی کدنویسی امن" },
        { nameof(GeneralProffesional.SecurityEvaluationStatusScore), "ارزیابی امنیتی" },
        { nameof(GeneralProffesional.BackupStatusScore), "وضعیت بکاپ" }
    };

            // لیست ستون‌های جدول GeneralChecklist
            var generalChecklistProperties = new[]
            {
        nameof(GeneralChecklist.OrganizationalSecurityStatusScore),
        nameof(GeneralChecklist.SecurityManagerStatusScore),
        nameof(GeneralChecklist.SecurityPolicyStatusScore),
        nameof(GeneralChecklist.SecurityChangeApprovalStatusScore),
        nameof(GeneralChecklist.ThirdPartyServiceStatusScore),
        nameof(GeneralChecklist.PersonnelHiringStatusScore),
        nameof(GeneralChecklist.AccessManagementStatusScore),
        nameof(GeneralChecklist.ComplianceManagementStatusScore),
        nameof(GeneralChecklist.IncidentResponseStatusScore)
    };

            // لیست ستون‌های جدول GeneralPolicy
            var generalPolicyProperties = new[]
            {
        nameof(GeneralPolicy.AuthenticationStatusScore),
        nameof(GeneralPolicy.BusinessIdentificationStatusScore),
        nameof(GeneralPolicy.EntryExitManagementStatusScore),
        nameof(GeneralPolicy.CCTVStatusScore),
        nameof(GeneralPolicy.HostingServiceStatusScore),
        nameof(GeneralPolicy.PrivacyPolicyStatusScore),
        nameof(GeneralPolicy.PublicComplaintsStatusScore),
        nameof(GeneralPolicy.CyberAttackResponseStatusScore),
        nameof(GeneralPolicy.DataSalesTradeStatusScore)
    };

            // لیست ستون‌های جدول GeneralProffesional
            var generalProffesionalProperties = new[]
            {
        nameof(GeneralProffesional.NetworkLogicalPhysicalMapStatusScore),
        nameof(GeneralProffesional.PhysicalAssetsInventoryStatusScore),
        nameof(GeneralProffesional.ZoningStatusScore),
        nameof(GeneralProffesional.AccessControlStatusScore),
        nameof(GeneralProffesional.DevelopmentTestOperationsControlStatusScore),
        nameof(GeneralProffesional.RemoteAdministrativeAccessStatusScore),
        nameof(GeneralProffesional.SecureCodingConfigStatusScore),
        nameof(GeneralProffesional.SecurityEvaluationStatusScore),
        nameof(GeneralProffesional.BackupStatusScore)
    };

            // محاسبه امتیازات جدول GeneralChecklist
            AddScoresFromTable(_companyContext.GeneralChecklists.ToList(), generalChecklistProperties, result, columnDisplayNames);

            // محاسبه امتیازات جدول GeneralPolicy
            AddScoresFromTable(_companyContext.GeneralPoliies.ToList(), generalPolicyProperties, result, columnDisplayNames);

            // محاسبه امتیازات جدول GeneralProffesional
            AddScoresFromTable(_companyContext.GeneralProffesionals.ToList(), generalProffesionalProperties, result, columnDisplayNames);

            // مرتب‌سازی براساس کمترین مجموع امتیازات و نمایش ۱۰ مورد اول
            return result.OrderBy(x => x.TotalScore).Take(10).ToList();
        }

        // متد کمکی برای محاسبه امتیازات هر جدول
        private void AddScoresFromTable<T>(List<T> tableData, string[] properties, List<(string PropertyName, long TotalScore)> result, Dictionary<string, string> columnDisplayNames)
        {
            foreach (var property in properties)
            {
                var totalScore = tableData
                    .Select(x => (long?)x.GetType().GetProperty(property)?.GetValue(x))
                    .Where(x => x.HasValue)
                    .Sum(x => x.Value); // جمع کل نمرات ستون

                // گرفتن نام دلخواه از دیکشنری
                string displayName = columnDisplayNames.ContainsKey(property)
                    ? columnDisplayNames[property]
                    : property; // اگر موجود نبود، از نام اصلی استفاده می‌شود

                result.Add((displayName, totalScore));
            }
        }





    }
}
