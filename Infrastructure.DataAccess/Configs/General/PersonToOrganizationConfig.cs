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
            builder.ToTable("PersonsToOrganization", "Module_general");
            builder.HasKey(e => new {e.PersonID,e.OrganizationID});

            builder.HasIndex(e => e.PersonID)
                .IsUnique(false);
            builder.HasIndex(e => e.OrganizationID)
                .IsUnique(false);
            builder.HasIndex(e => new { e.PersonID, e.OrganizationID })
                .IsUnique(true);

            builder
                .HasOne(rel => rel.FKOrganization)
                .WithMany(org => org.FKPersonToOrganization)
                .HasForeignKey(FK => FK.OrganizationID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(rel => rel.FKPerson)
                .WithMany(persona => persona.FKPersonToOrganization)
                .HasForeignKey(FK => FK.PersonID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
