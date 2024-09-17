using _0_Framework.Domain;
using AccountManagement.Domain;
using CompanyManagement.Domain.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklistmanagement.Domain
{
    public class Checklist: EntityBase
    {
        
        public int Score { get; private set; }
        public string Description { get; private set; }
        public long CompanyId { get; private set; }
        public long AgentId { get; private set; }
        public Company Company { get; private set; }
        public Account Agent { get; private set; }
    }
}
