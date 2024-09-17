using CompanyManagement.Domain.CompanyAgg;
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
    public class HpEdl380Mapping : IEntityTypeConfiguration<HPEDL380>
    {
        public void Configure(EntityTypeBuilder<HPEDL380> builder)
        {
            builder.ToTable("HPEDL380s");
            builder.HasKey(x => x.Id);
         
            


            builder.HasOne(c => c.Checklist)
                .WithOne(h => h.HPEDL380)
                .HasForeignKey<Checklist>(c => c.HPEDL380ID);


          

        }
    }

}
