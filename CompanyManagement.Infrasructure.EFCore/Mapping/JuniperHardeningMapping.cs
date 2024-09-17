using CompanyManagement.Domain.CompanyAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
    public class JuniperHardeningMapping : IEntityTypeConfiguration<JuniperHardening>
    {
        public void Configure(EntityTypeBuilder<JuniperHardening> builder)
        {
            builder.ToTable("JuniperHardenings");
            builder.HasKey(x => x.Id);
         
            


            builder.HasOne(c => c.Checklist)
                .WithOne(h => h.JuniperHardening)
                .HasForeignKey<Checklist>(c => c.JuniperHardeningID);


           

        }
    }

}
