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
    internal class OrganizationConfig : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations", "Module_general");
            builder.HasKey(org => org.OrganizationID);

            builder
                .HasOne(org => org.FKActivityLog)
                .WithOne(log => log.FKOrganization)
                .HasForeignKey<Organization>(FK => FK.ActivityLogID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasMany(org => org.FKPersonToOrganization)
               .WithOne(rel => rel.FKOrganization);

            builder
               .HasMany(org => org.FKProfileToOrganizations)
               .WithOne(rel => rel.FKOrganization);
        }
    }
}
