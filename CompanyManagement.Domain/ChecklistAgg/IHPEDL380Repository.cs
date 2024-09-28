using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;

namespace CompanyManagement.Domain.ChecklistAgg
{
    
        public interface IHPEDL380Repository : IRepository<long, HPEDL380>
        {
            EditHPEDL380Checklist Getdetails(long id);

    }
    
}
