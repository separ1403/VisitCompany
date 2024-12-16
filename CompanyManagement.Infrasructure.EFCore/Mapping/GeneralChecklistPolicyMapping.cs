using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Domain.ChecklistAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{


    public class GeneralChecklistPolicyMapping : IEntityTypeConfiguration<GeneralPolicy>
    {
        public void Configure(EntityTypeBuilder<GeneralPolicy> builder)
        {
            builder.ToTable("GeneralPolicies");
            builder.HasKey(x => x.Id);




            builder.HasOne(c => c.Checklist)
                .WithOne(h => h.GeneralPolicy)
                .HasForeignKey<Checklist>(c => c.GeneralChecklistPolicyID);




        }
    }
}
