using CompanyManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrasructure.EFCore.Mapping
{
    public class LoginAttemptMapping : IEntityTypeConfiguration<LoginAttempt>
    {
        public void Configure(EntityTypeBuilder<LoginAttempt> builder)
        {
            builder.ToTable("LoginAttempts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LoginTime).IsRequired();
            builder.HasOne(x => x.Account)
                   .WithMany(x => x.LoginAttempts)
                   .HasForeignKey(x => x.AccountId);
        }
    }
}
