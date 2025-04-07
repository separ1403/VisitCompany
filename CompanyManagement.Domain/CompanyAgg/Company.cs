using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using CompanyManagement.Domain.StatesCategoryAgg;
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
    public string? Address { get; private set; }
    public long? CountEmployees { get; private set; }
    public long? CountFolowers { get; private set; }

    public long CategoryId { get; private set; }
    public long? ChecklistId { get; private set; }
    public DateTime? ReferDateFrom { get; set; }
    public DateTime? ReferDateTo { get; set; }

    public DateTime? CheckDate { get; set; }

    public StateCategory StateCategory { get; private set; }
    public long StateCategoryIds { get; private set; }

    public List<LicenceCategory> LicenceCategories { get; private set; } = new List<LicenceCategory>();
    public List<long> LicenceIds { get; private set; }
    public List<Checklist> Checklists { get; private set; }
    public CompanyCategory CompanyCategory { get; private set; }
    public List<Account> Accounts { get; private set; } = new List<Account>();
   // public List<long>? AccountIds { get; private set; }
    public string? PostalCode { get; private set; }

    //  public List<long>? PeopleIds { get; private set; }
    public List<Person> People { get; private set; } = new List<Person>();

    // ذخیره مقدار قبلی Description
    private string? _previousDescription;
    public string? Domain { get; private set; }

    //for ramio
    public string? TitleRasm { get; private set; }
    public string? RegistrationDateRasm { get; private set; }
    public string? RegistrationNoRasm { get; private set; }
    public decimal? CapitalRasm { get; private set; }
    public string? AddressRasm { get; private set; }
    public string? TaxNumberRasm { get; private set; }
    public string? PostalCodeRasm { get; private set; }
    public string? LastUpdateRasm { get; private set; }
    public string? StatusRasm { get; private set; }
    public string? EdareKolRasm { get; private set; }
    public string? VahedSabtiRasm { get; private set; }

    // سازنده پیش‌فرض
    public Company()
    {
        _previousDescription = string.Empty; // مقداردهی اولیه _previousDescription
    }

    // سازنده با پارامترها
    public Company(string companyName, string brand, string managerName, string securityManagerName, 
        string phoneNumber, string description, string nationalCode, string address,
        long categoryId, List<long> licenceIds, List<Account> accounts, string domain,
        DateTime referDateFrom, DateTime referDateTo, long stateCategoryId, List<Person> people,
        long countEmployees, long countFolowers, string postacode/*, DateTime checkDate*/
        , string? titleRasm ,string  registrationDateRasm , string registrationNoRasm , decimal capitalRasm 
        , string addressRasm ,string  taxNumberRasm ,string postalCodeRasm , string lastUpdateRasm , string statusRasm
        , string edareKolRasm , string vahedSabtiRasm)
    {
        CompanyName = companyName;
        Brand = brand;
        ManagerName = managerName;
        SecurityManagerName = securityManagerName;
        PhoneNumber = phoneNumber;
        Description = description;
        _previousDescription = description ?? null; // مقداردهی اولیه _previousDescription
        NationalCode = nationalCode;
        Address = address;
        CategoryId = categoryId;
        LicenceIds = licenceIds;
        IsActive = true;
        Accounts = accounts ?? new List<Account>();
        Domain = domain;
        ReferDateFrom = referDateFrom;
        ReferDateTo = referDateTo;
        CreationDate = DateTime.Now;
        StateCategoryIds = stateCategoryId;
        People = people;  // تخصیص لیست اشخاص
        CountEmployees = countEmployees;
        CountFolowers = countFolowers;
        PostalCode = postacode;
        TitleRasm = titleRasm;
        RegistrationDateRasm = registrationDateRasm;
        RegistrationNoRasm = registrationNoRasm;
        CapitalRasm = capitalRasm;
        AddressRasm = addressRasm;
        TaxNumberRasm = taxNumberRasm;
        PostalCodeRasm = postalCodeRasm;
        LastUpdateRasm = lastUpdateRasm;
        StatusRasm = statusRasm;
        EdareKolRasm = edareKolRasm;
        VahedSabtiRasm = vahedSabtiRasm;
        // CheckDate = Checklists;
    }

    public void AddAccounts(List<Account> accounts)
    {
        foreach (var account in accounts)
        {
            Accounts.Add(account);
        }
    }

    public void AddLicence(List<LicenceCategory> licences)
    {
        foreach (var licence in licences)
        {
            LicenceCategories.Add(licence);
        }
    }


    public void Edit(string companyName, string brand, string managerName, string securityManagerName, string phoneNumber, string? description, string nationalCode, string address, long categoryId, List<long> licenceIds, List<Account> accounts, string domain, DateTime referDateFrom, DateTime referDateTo, long stateCategoryId, List<long> peopleIds, long countEmployees, long countFolowers, string postacode, DateTime? checkDate)
    {
        
        if (!string.IsNullOrWhiteSpace(companyName))
            CompanyName = companyName;

        if (!string.IsNullOrWhiteSpace(brand))
            Brand = brand;

        if (!string.IsNullOrWhiteSpace(managerName))
            ManagerName = managerName;


        if (!string.IsNullOrWhiteSpace(securityManagerName))
            SecurityManagerName = securityManagerName;

        if (!string.IsNullOrWhiteSpace(phoneNumber))
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

        if (!string.IsNullOrWhiteSpace(nationalCode))
            NationalCode = nationalCode;

        if (!string.IsNullOrWhiteSpace(address))
            Address = address;

        if (categoryId > 0)
            CategoryId = categoryId;

        if (licenceIds != null)

            LicenceIds = licenceIds;


        if (accounts != null)
        {
            // حذف accountهایی که دیگه نباید باشن
            Accounts.RemoveAll(a => !accounts.Any(x => x.Id == a.Id));

            // اضافه کردن فقط accountهایی که جدید هستن
            foreach (var acc in accounts)
            {
                if (!Accounts.Any(x => x.Id == acc.Id))
                    Accounts.Add(acc);
            }
        }



        if (!string.IsNullOrWhiteSpace(domain))

            Domain = domain;

        //if (checkDate != DateTime.MinValue)
        //{
        //    CheckDate = checkDate;
        //}

        if (referDateFrom != DateTime.MinValue)
        {
            ReferDateFrom = referDateFrom;
        }
        if (referDateTo != DateTime.MinValue)
        {
            ReferDateTo = referDateTo;
        }

        if (checkDate.HasValue)
        {
            CheckDate = checkDate.Value;
        }

        CreationDate = DateTime.Now; // تاریخ بروز رسانی میشه 
        // یه تارخ باید به دیتابیس اضافه کنم که توش فقط تو این متد تاریخ بروز رسانی رو بزارم و تو ایندکس هم نمایشش بدم و این تاریخ رو از اینجا حذف بکنم
        if (stateCategoryId != 0)
            StateCategoryIds = stateCategoryId;

        //if (peopleIds != null)

        //    PeopleIds = peopleIds;

        if (countEmployees > 0)
            CountEmployees = countEmployees;

        if (countFolowers > 0)
            CountFolowers = countFolowers;

    }

    public void EditRasmio(string? titleRasm = null, string? registrationDateRasm = null, string? registrationNoRasm = null, decimal? capitalRasm = null,
    string? addressRasm = null, string? taxNumberRasm = null, string? postalCodeRasm = null, string? lastUpdateRasm = null,
    string? statusRasm = null, string? edareKolRasm = null, string? vahedSabtiRasm = null)
    {
        // فقط پراپرتی‌هایی که مقدار جدید دارند، بروزرسانی می‌شوند
        if (!string.IsNullOrWhiteSpace(titleRasm))
            TitleRasm = titleRasm;

        if (!string.IsNullOrWhiteSpace(registrationDateRasm))
            RegistrationDateRasm = registrationDateRasm;

        if (!string.IsNullOrWhiteSpace(registrationNoRasm))
            RegistrationNoRasm = registrationNoRasm;

        if (capitalRasm.HasValue && capitalRasm > 0)
            CapitalRasm = capitalRasm;

        if (!string.IsNullOrWhiteSpace(addressRasm))
            AddressRasm = addressRasm;

        if (!string.IsNullOrWhiteSpace(taxNumberRasm))
            TaxNumberRasm = taxNumberRasm;

        if (!string.IsNullOrWhiteSpace(postalCodeRasm))
            PostalCodeRasm = postalCodeRasm;

        if (!string.IsNullOrWhiteSpace(lastUpdateRasm))
            LastUpdateRasm = lastUpdateRasm;

        if (!string.IsNullOrWhiteSpace(statusRasm))
            StatusRasm = statusRasm;

        if (!string.IsNullOrWhiteSpace(edareKolRasm))
            EdareKolRasm = edareKolRasm;

        if (!string.IsNullOrWhiteSpace(vahedSabtiRasm))
            VahedSabtiRasm = vahedSabtiRasm;
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
