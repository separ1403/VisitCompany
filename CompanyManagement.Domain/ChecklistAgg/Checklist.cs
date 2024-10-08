using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.AccountAgg;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class Checklist : EntityBase
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public long? CountEmployees { get; private set; } 
        public long? CountFolowers { get; private set; }
        public long? CompanyId { get; private set; }
        public List<long>? AccountIds { get; private set; }
        public Company? Company { get; private set; }
        public List<Account>? Accounts { get; private set; }

        public List<long>? PeopleIds { get; private set; }
        public List<Person> People { get; private set; } = new List<Person>();






        //professional

        public long? JuniperHardeningID { get; private set; }
        public long? HPEDL380ID { get; private set; }
        public long? Win2019ID { get; private set; }
        public long? GeneralChecklistID { get; private set; }



        // Navigation properties for specialized checklists
        public JuniperHardening? JuniperHardening { get; set; }
        public HPEDL380? HPEDL380 { get; set; }
        public Win2019? Win2019 { get; set; }
        public GeneralChecklist? GeneralChecklist { get; set; }


        public Checklist(string title, string description, List<Person> people, long countEmployees, long countFolowers, long companyId, List<long> accountIds)
        {
            Title = title;
            Description = description;
            People = people;  // تخصیص لیست اشخاص
            CountEmployees = countEmployees;
            CountFolowers = countFolowers;
            CompanyId = companyId;
            AccountIds = accountIds;

            CreationDate = DateTime.Now;
        }

        public Checklist()
        {
            // Parameterless constructor
        }

        public void Editjunior(long juniperHardeningID)
        {
            if (juniperHardeningID != 0)
            {
                JuniperHardeningID = juniperHardeningID;
            }
        }


        public void EditHPEDL380(long hPEDL380ID)
        {
            if (hPEDL380ID != 0)
            {
                HPEDL380ID = hPEDL380ID;
            }
        }

        public void EditWin2019(long win2019ID)
        {
            if (win2019ID != 0)
            {
                Win2019ID = win2019ID;
            }
        }

        public void EditGeneralChecklist(long generalChecklistID)
        {
            if (generalChecklistID != 0)
            {
                GeneralChecklistID = generalChecklistID;
            }
        }








    }


}
