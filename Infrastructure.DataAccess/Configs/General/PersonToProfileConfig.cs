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
            builder.ToTable("PersonToProfile");
            builder.HasKey(e => new { e.PersonID, e.ProfileID });

            builder
                .HasOne(e => e.FKPerson)
                .WithOne(person => person.FKPersonToProfile);

            builder
                .HasOne(e => e.FKProfile)
                .WithOne(profile => profile.FKPersonToProfile);
        }
    }
}
