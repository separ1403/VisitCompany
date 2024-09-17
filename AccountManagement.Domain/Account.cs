using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain
{
    public class Account:EntityBase
    {
        public string Fullname { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public string ProfilePhoto { get; private set; }
        public string CodeValidateMobile { get; private set; }
        public bool IsActive { get; private set; }
        //  public Role Role { get; private set; } felan deactive
    }
}
