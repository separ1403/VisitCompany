using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class Person:EntityBase
    {
        public Person(string namePeopleCo, string rspponsePeopleCo, string phonePeopleCo)
        {
            NamePeopleCo = namePeopleCo;
            RspponsePeopleCo = rspponsePeopleCo;
            PhonePeopleCo = phonePeopleCo;
        }

        public string NamePeopleCo { get; set; }
        public string RspponsePeopleCo { get; set; }
        public string PhonePeopleCo { get; set; }
        public Checklist Checklist { get; set; }


        public Person()
        {
           
        }

    }
}
