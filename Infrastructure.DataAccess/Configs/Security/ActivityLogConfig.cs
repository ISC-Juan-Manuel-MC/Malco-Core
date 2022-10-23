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
               .HasOne(log => log.FKOrganization)
               .WithOne(org => org.FKActivityLog);


            builder
               .HasOne(log => log.FKProfile)
               .WithOne(profile => profile.FKActivityLog);

            builder
              .HasOne(log => log.FKPerson)
              .WithOne(person => person.FKActivityLog);

            builder
               .HasOne(log => log.FKView)
               .WithOne(view => view.FKActivityLog);

            builder
               .HasOne(log => log.FKActivityLog)
               .WithOne();

            builder
               .HasOne(log => log.FKActivityLog)
               .WithOne()
               .HasForeignKey<ActivityLog>(FK => FK.ActivityLogIDReference)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
