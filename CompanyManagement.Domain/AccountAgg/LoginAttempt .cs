using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.AccountAgg
{
    public  class LoginAttempt:EntityBase
    {
        public DateTime LoginTime { get; private set; }
        public long AccountId { get; private set; }
        public Account Account { get; private set; }

        public LoginAttempt(long accountId)
        {
            AccountId = accountId;
            LoginTime = DateTime.Now;
        }
    }
}
