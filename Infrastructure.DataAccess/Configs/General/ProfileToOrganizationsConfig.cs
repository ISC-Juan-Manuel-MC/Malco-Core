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
    internal class ProfileToOrganizationsConfig : IEntityTypeConfiguration<ProfileToOrganizations>
    {
        public void Configure(EntityTypeBuilder<ProfileToOrganizations> builder)
        {
            builder.ToTable("ProfileToOrganizations", "Module_general");
            builder.HasKey(e => new { e.ProfileID, e.OrganizationID });

            builder
                .HasOne(rel => rel.FKOrganization)
                .WithMany(org => org.FKProfileToOrganizations)
                .HasForeignKey(FK => FK.OrganizationID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(rel => rel.FKProfile)
                .WithMany(profile => profile.FKProfileToOrganizations)
                .HasForeignKey(FK => FK.ProfileID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
