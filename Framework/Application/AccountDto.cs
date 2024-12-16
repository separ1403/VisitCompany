using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class AccountDto
    {
        public AccountDto(long id, string fullName, long stateCategoryId)
        {
            Id = id;
            FullName = fullName;
            StateCategoryId = stateCategoryId;
        }

        public long Id { get; private set; }
        public string FullName { get; private set; }
        public long StateCategoryId { get; private set; } // افزودن CategoryStateId
    }

}
