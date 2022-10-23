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
    internal class PersonToProfileConfig : IEntityTypeConfiguration<PersonToProfile>
    {
        public void Configure(EntityTypeBuilder<PersonToProfile> builder)
        {
            builder.ToTable("PersonToProfile", "Module_general");
            builder.HasKey(e => new { e.PersonID, e.ProfileID });

            builder
                .HasOne(rel => rel.FKPerson)
                .WithOne(person => person.FKPersonToProfile)
                .HasForeignKey<PersonToProfile>(FK => FK.PersonID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(rel => rel.FKProfile)
                .WithOne(profile => profile.FKPersonToProfile)
                .HasForeignKey<PersonToProfile>(FK => FK.ProfileID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
