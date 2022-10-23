using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using MCC.Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configs.Security
{
    internal class ActivityLogConfig : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.ToTable("ActivityLogs", "Module_security");
            builder.HasKey(Log => Log.ActivityLogID);

            builder
                .HasOne(log => log.FKApp)
                .WithOne();

            builder
               .HasOne(e => e.FKOrganization)
               .WithOne();


            builder
               .HasOne(e => e.FKProfile)
               .WithOne();

            builder
               .HasOne(e => e.FKView)
               .WithOne();

            builder
               .HasOne(e => e.FKActivityLog)
               .WithOne();

            /*
            builder
                .HasOne(org => org.FKActivityLog)
                .WithOne()
                .HasForeignKey<ActivityLog>(FK => FK.ActivityLogID);
            */

        }
    }
}
