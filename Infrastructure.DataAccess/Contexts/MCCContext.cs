using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Domain.Models.General;
using Infrastructure.DataAccess.Configs.General;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataAccess.Properties;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DataAccess.Contexts
{
    public class MCCContext: DbContext
    {
        #region GeneralModule
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationRating> OrganizationRating { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonToOrganization> PersonToOrganization { get; set; }
        public DbSet<PersonToProfile> PersonToProfile { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileToOrganizations> ProfileToOrganizations { get; set; }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data source=" + Resources.Server + "; " +
                                 "Initial Catalog=" + Resources.Database + "; " +
                                 "User Id=" + Resources.User + "; " +
                                 "Password=" + Resources.Password);
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

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");
        }
    }


    //Source https://github.com/dotnet/efcore/issues/24507
    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }

    /// <summary>
    /// Converts <see cref="DateOnly?" /> to <see cref="DateTime?"/> and vice versa.
    /// </summary>
    public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public NullableDateOnlyConverter() : base(
            d => d == null
                ? null
                : new DateTime?(d.Value.ToDateTime(TimeOnly.MinValue)),
            d => d == null
                ? null
                : new DateOnly?(DateOnly.FromDateTime(d.Value)))
        { }
    }

}
