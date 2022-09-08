using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using Infrastructure.DataAccess.Configs.General;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts
{
    internal class MCCContext: DbContext
    {

        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationRating> OrganizationRating { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonToOrganization> PersonToOrganization { get; set; }
        public DbSet<PersonToProfile> PersonToProfile { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileToOrganizations> ProfileToOrganizations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Conexion");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new OrganizationConfig());
            builder.ApplyConfiguration(new OrganizationRatingConfig());
            builder.ApplyConfiguration(new PersonConfig());
            builder.ApplyConfiguration(new PersonToOrganizationConfig());
            builder.ApplyConfiguration(new PersonToProfileConfig());
            builder.ApplyConfiguration(new ProfileConfig());
            builder.ApplyConfiguration(new ProfileToOrganizationsConfig());

        }
    }
}
