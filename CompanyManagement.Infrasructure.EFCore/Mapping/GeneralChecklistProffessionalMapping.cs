using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompanyManagement.Domain.ChecklistAgg;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
    

    public class GeneralChecklistProffessionalMapping : IEntityTypeConfiguration<GeneralProffesional>
    {
        public void Configure(EntityTypeBuilder<GeneralProffesional> builder)
        {
            builder.ToTable("GeneralProffesionals");
            builder.HasKey(x => x.Id);




            builder.HasOne(c => c.Checklist)
                .WithOne(h => h.GeneralProffesional)
                .HasForeignKey<Checklist>(c => c.GeneralChecklistProfessionalID);




        }
    }
}
