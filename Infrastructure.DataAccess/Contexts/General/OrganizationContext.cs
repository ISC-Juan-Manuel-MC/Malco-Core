using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using Infrastructure.DataAccess.Configs.General;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts.General
{
    //Es posible que se necesite crear un contexto para cada servicio incluyendo las entidades en cuestion
    internal class OrganizationContext : DbContext
    {
        public DbSet<Organization> Organization { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Conexion");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new OrganizationConfig());
        }
    }
}
