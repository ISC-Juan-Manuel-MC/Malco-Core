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
    internal class PersonToOrganizationConfig : IEntityTypeConfiguration<PersonToOrganization>
    {
        public void Configure(EntityTypeBuilder<PersonToOrganization> builder)
        {
            builder.ToTable("PersonsToOrganization");
            builder.HasKey(e => new {e.PersonID,e.OrganizationID});

            builder
                .HasOne(e => e.FKOrganization)
                .WithMany(org => org.FKPersonToOrganization);

            builder
                .HasOne(e => e.FKPerson)
                .WithMany(person => person.FKPersonToOrganization);
        }
    }
}
