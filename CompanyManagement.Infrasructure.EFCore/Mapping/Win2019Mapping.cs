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
    public class Win2019Mapping : IEntityTypeConfiguration<Win2019>
    {
        public void Configure(EntityTypeBuilder<Win2019> builder)
        {
            builder.ToTable("Win2019s");
            builder.HasKey(x => x.Id);




            builder.HasOne(c => c.Checklist)
                .WithOne(h => h.Win2019)
                .HasForeignKey<Checklist>(c => c.Win2019ID);




        }
    }

}
