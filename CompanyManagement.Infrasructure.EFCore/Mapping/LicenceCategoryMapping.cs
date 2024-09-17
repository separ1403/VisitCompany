using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
    public class LicenceCategoryMapping : IEntityTypeConfiguration<LicenceCategory>
    {
        public void Configure(EntityTypeBuilder<LicenceCategory> builder)
        {
            builder.ToTable("LicenceCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasMany(x => x.Companies).WithMany(x => x.LicenceCategories);
                
        }

    }
}
