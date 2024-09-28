using CompanyManagement.Domain.ChecklistAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
   

    public class GeneralChecklistMapping : IEntityTypeConfiguration<GeneralChecklist>
    {
        public void Configure(EntityTypeBuilder<GeneralChecklist> builder)
        {
            builder.ToTable("GeneralChecklists");
            builder.HasKey(x => x.Id);




            builder.HasOne(c => c.Checklist)
                .WithOne(h => h.GeneralChecklist)
                .HasForeignKey<Checklist>(c => c.GeneralChecklistID);




        }
    }
}
