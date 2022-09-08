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
    internal class OrganizationRatingConfig : IEntityTypeConfiguration<OrganizationRating>
    {
        public void Configure(EntityTypeBuilder<OrganizationRating> builder)
        {
            builder.ToTable("OrganizationRating");
            builder.HasKey(e => new { e.OrganizationID, e.OrganizationRatingID });

            builder
                .HasOne(rating => rating.FKOrganization)
                .WithMany(org => org.FKOrganizationRating);
        }
    }
}
