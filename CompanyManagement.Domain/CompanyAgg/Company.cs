using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using Framework.Domain;

public class Company : EntityBase
{
    public string? CompanyName { get; private set; }
    public string? Brand { get; private set; }
    public string? ManagerName { get; private set; }
    public string? SecurityManagerName { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public string? NationalCode { get; private set; }
    public double Average { get; private set; }
    public long CategoryId { get; private set; }
    public long ChecklistId { get; private set; }
    public long LicenceId { get; private set; }
    public List<Checklist> Checklists { get; private set; }
    public CompanyCategory CompanyCategory { get; private set; }
    public List<LicenceCategory> LicenceCategories { get; private set; }
    public List<Account> Accounts { get; private set; } = new List<Account>();
    public List<long> AccountIds { get; private set; }

    // ذخیره مقدار قبلی Description
    private string? _previousDescription;

    // سازنده پیش‌فرض
    public Company()
    {
        _previousDescription = string.Empty; // مقداردهی اولیه _previousDescription
    }

    // سازنده با پارامترها
    public Company(string companyName, string brand, string managerName, string securityManagerName, string phoneNumber, string description, string nationalCode, long categoryId, long licenceId, List<long> accountIds)
    {
        CompanyName = companyName;
        Brand = brand;
        ManagerName = managerName;
        SecurityManagerName = securityManagerName;
        PhoneNumber = phoneNumber;
        Description = description;
        _previousDescription = description ?? null; // مقداردهی اولیه _previousDescription
        NationalCode = nationalCode;
        CategoryId = categoryId;
        LicenceId = licenceId;
        IsActive = true;
        AccountIds = accountIds;
    }

    public void AddAccounts(List<Account> accounts)
    {
        foreach (var account in accounts)
        {
            Accounts.Add(account);
        }
    }

    public void Edit(string companyName, string brand, string managerName, string securityManagerName, string phoneNumber, string? description, string nationalCode, long categoryId, long licenceId,List<long> accountIds)
    {
        CompanyName = companyName;
        Brand = brand;
        ManagerName = managerName;
        SecurityManagerName = securityManagerName;
        PhoneNumber = phoneNumber;

        // مقداردهی اولیه _previousDescription در صورت نیاز
        if (string.IsNullOrWhiteSpace(_previousDescription))
        {
            _previousDescription = Description ?? null;
        }

    if (!string.Equals(_previousDescription?.Trim(), description?.Trim(), StringComparison.Ordinal))
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            if (description == null)
            {
                Description = $"{_previousDescription}\n(تلاش برای حذف کامل توضیحات در تاریخ {timeStamp} - این عمل مجاز نیست)\n";

            }

            else if (description != null && description.Length < (_previousDescription?.Length ?? 0))
            {
                // حذف محتوا صورت گرفته است
                Description = $"{_previousDescription}\n(تلاش برای حذف بخشی از توضیحات در تاریخ {timeStamp} - این عمل مجاز نیست)\n";
            }
            
            else
            {
                // تغییر یا افزودن محتوا صورت گرفته است
                Description = $"\n{description?.Trim()} (افزودن توضیحات در تاریخ {timeStamp})\n";
            }

            _previousDescription = description ?? string.Empty; // به‌روز رسانی مقدار قبلی

        }
        else
        {
            //وقتی تغییری نکرده
            Description = description;
        }

        NationalCode = nationalCode;
        CategoryId = categoryId;
        LicenceId = licenceId;
        AccountIds = accountIds;
    }

    public void Active()
    {
        IsActive = true;
    }

    public void DeActive()
    {
        IsActive = false;
    }
}
