using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class AccountDto
    {
        public AccountDto(long id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public long Id { get; private set; }
        public string FullName { get; private set; }
    }
}
