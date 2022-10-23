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
    internal class ProfileConfig : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles", "Module_general");
            builder.HasKey(profile => profile.ProfileID);

            builder
                .HasOne(prof => prof.FKActivityLog)
                .WithOne(log => log.FKProfile)
                .HasForeignKey<Profile>(FK => FK.ActivityLogID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasMany(profile => profile.FKProfileToOrganizations)
               .WithOne(rel => rel.FKProfile);

            builder
              .HasOne(profile => profile.FKPersonToProfile)
              .WithOne(rel => rel.FKProfile);
        }
    }
}
