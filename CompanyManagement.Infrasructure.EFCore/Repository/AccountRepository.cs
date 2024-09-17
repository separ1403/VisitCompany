﻿using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using CompanyManagement.Infrasructure.EFCore;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public  class AccountRepository:RepositoryBase<long,Account> , IAccountRepository
    {
        private readonly CompanyContext _context;
        public AccountRepository( CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<Account> GetAccountsByIds(List<long> accountIds)
        {
            return _context.Accounts.Where(a => accountIds.Contains(a.Id)).ToList();// account hayee ro az table account mide ke id on ha barabar bashe ba Accountids ha
            //yani az roye accountid ha account ha ro joda mikone
        }

        public AccountViewModel GetLastLogin(string searchModel)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                UserName = x.UserName,
                LastLogin = x.LastLogin.ToFarsiWithTime(),
                PreviousLogin=x.PreviousLogin.ToFarsiWithTime()
                
            });

            if (!string.IsNullOrWhiteSpace(searchModel))
                query = query.Where(x => x.UserName.Equals(searchModel) || x.Mobile.Equals(searchModel));

            // استفاده از FirstOrDefault برای گرفتن اولین نتیجه یا مقدار پیش‌فرض (null) اگر هیچ نتیجه‌ای موجود نباشد
            return query.FirstOrDefault();
        }


        public Account GetBy(string username)
        {
            
            return _context.Accounts.FirstOrDefault(x => x.UserName == username);
        }

        public Account GetByMobile(string mobile)
        {
            return _context.Accounts.FirstOrDefault(x => x.Mobile == mobile);
        }


        public List<AccountViewModel> GetAccounts()
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname
            }).ToList();
        }

        public EditAccount Getdetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.UserName
            }).FirstOrDefault(x => x.Id == id);
        }

        public ChangePassword Getdetail(long id)
        {
            return _context.Accounts.Select(x => new ChangePassword()
            {
                Id = x.Id,
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Serach(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Include(x=>x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                Role=x.Role.Name,
                RoleId = x.RoleId,
                UserName = x.UserName,
                CreationDate=x.CreationDate.ToFarsiWithTime(),
                LastLogin = x.LastLogin.ToFarsiWithTime(),
                PreviousLogin = x.PreviousLogin.HasValue ? x.PreviousLogin.Value.ToFarsiWithTime() : "N/A"

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.UserName.Contains(searchModel.UserName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public bool ActiveUser(string activeCode)
        {
            var account =
                _context.Accounts.FirstOrDefault(x => x.IsActive == false );
            if (account != null)
            {
               account.ChangeActiveMode();

                _context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}