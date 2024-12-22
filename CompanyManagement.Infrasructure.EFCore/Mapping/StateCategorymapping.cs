using CompanyManagement.Domain.CompanyCategoryAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Domain.StatesCategoryAgg;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
    public class StateCategorymapping : IEntityTypeConfiguration<StateCategory>
    {
        public void Configure(EntityTypeBuilder<StateCategory> builder)
        {
            builder.ToTable("StateCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Accounts).WithOne(x => x.StateCategory).HasForeignKey(x => x.StateCategoryId);

            builder.HasMany(x => x.companies).WithOne(x => x.StateCategory).HasForeignKey(x => x.StateCategoryIds).OnDelete(DeleteBehavior.NoAction); // جلوگیری از ایجاد مسیرهای چندگانه
        }

    }
}
