using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configs.Security
{
    internal class AppConfig : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.ToTable("Apps", "Module_security");
            builder.HasKey(app => app.AppID);

            builder
                .HasOne(app => app.FKActivityLog)
                .WithOne(log => log.FKApp)
                .HasForeignKey<App>(FK => FK.ActivityLogID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
