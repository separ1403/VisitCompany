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
    

    public class PeopleMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);




            builder.HasOne(c => c.Checklist)
                .WithMany(h => h.People);




        }
    }
}
