﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Account
{
    public  class AccountSearchModel
    {
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public long StateCategoryId { get; set; }
        public long RoleId { get; set; }  // inja admin mikhad saerch kone pass role id ro mifahme
        
    }
}
