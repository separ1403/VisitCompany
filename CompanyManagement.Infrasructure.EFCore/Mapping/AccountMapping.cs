﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Infrasructure.EFCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{

    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fullname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();
            //builder.Property(x => x.Password).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(20).IsRequired();

            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);


            builder.HasMany(x => x.Checklists)
                   .WithMany(x => x.Accounts)
                   .UsingEntity<Dictionary<string, object>>(
            "AccountChecklist",
                       j => j.HasOne<Checklist>().WithMany().HasForeignKey("ChecklistId"), 
                       j => j.HasOne<Account>().WithMany().HasForeignKey("AccountId"));


            builder.HasOne(x => x.StateCategory).WithMany(x => x.Accounts).HasForeignKey(x => x.StateCategoryId);

            builder.HasMany(x => x.LoginAttempts).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
            //  builder.HasMany(x => x.Companies).WithMany(x => x.Accounts);


            builder.HasMany(a => a.Companies)
              .WithMany(c => c.Accounts)
              .UsingEntity<Dictionary<string, object>>(
                  "CompanyAccount",
                  j => j.HasOne<Company>().WithMany().HasForeignKey("CompanyId"),
                  j => j.HasOne<Account>().WithMany().HasForeignKey("AccountId"));
        }
    }

}
