using AccountManagement.Domain.AccountAgg;
using CompanyManagement.Domain.CompanyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CompanyName).HasMaxLength(500);
            builder.Property(x => x.Brand).HasMaxLength(255);
            builder.Property(x => x.ManagerName).HasMaxLength(255);
            builder.Property(x => x.SecurityManagerName).HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).HasMaxLength(255);

            builder.HasMany(x => x.Checklists).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.CompanyCategory).WithMany(x => x.Companies).HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.LicenceCategories).WithMany(x => x.Companies);

            // builder.HasMany(x => x.Accounts).WithMany(x => x.Companies);

            builder.HasMany(c => c.Accounts)
              .WithMany(a => a.Companies)
              .UsingEntity<Dictionary<string, object>>(
                  "CompanyAccount",
                  j => j.HasOne<Account>().WithMany().HasForeignKey("AccountId"),
                  j => j.HasOne<Company>().WithMany().HasForeignKey("CompanyId"));
        }
    }

}