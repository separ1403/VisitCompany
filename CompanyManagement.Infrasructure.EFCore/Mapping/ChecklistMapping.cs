﻿using CompanyManagement.Domain.CompanyAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Domain.ChecklistAgg;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
    public class ChecklistMapping : IEntityTypeConfiguration<Checklist>
    {
        public void Configure(EntityTypeBuilder<Checklist> builder)
        {
            builder.ToTable("Checklists");
            builder.HasKey(x => x.Id);
         
            


            builder.HasOne(x => x.Company).WithMany(x => x.Checklists).HasForeignKey(x => x.CompanyId);
            builder.HasMany(x => x.Accounts).WithMany(x => x.Checklists);
            builder.HasOne(x => x.HPEDL380).WithOne(x => x.Checklist);
            builder.HasOne(x => x.JuniperHardening).WithOne(x => x.Checklist);
            builder.HasOne(x => x.GeneralChecklist).WithOne(x => x.Checklist);
            builder.HasMany(x => x.People) .WithOne(x=>x.Checklist);


           

        }
    }

}
