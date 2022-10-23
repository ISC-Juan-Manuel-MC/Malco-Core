using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configs.General
{
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", "Module_general");
            builder.HasKey(person => person.PersonID);

            builder
               .HasMany(persona => persona.FKPersonToOrganization)
               .WithOne(rel => rel.FKPerson);

            builder
               .HasOne(persona => persona.FKPersonToProfile)
               .WithOne(rel => rel.FKPerson);

        }
    }
}
