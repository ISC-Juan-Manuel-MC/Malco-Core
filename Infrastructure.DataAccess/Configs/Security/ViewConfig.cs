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
    internal class ViewConfig : IEntityTypeConfiguration<Views>
    {
        public void Configure(EntityTypeBuilder<Views> builder)
        {
            builder.ToTable("Views", "Module_security");
            builder.HasKey(view => view.ViewID);

            builder
                .HasOne(view => view.FKActivityLog)
                .WithOne(log => log.FKView)
                .HasForeignKey<Views>(FK => FK.ActivityLogID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
