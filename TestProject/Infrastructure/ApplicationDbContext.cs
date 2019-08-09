using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Core.Models.Entities;

namespace TestProject.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Make DateTime values' kind be UTC by default
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var prop in entityType.GetProperties())
                {
                    if (prop.ClrType == typeof(DateTime))
                    {
                        builder
                            .Entity(entityType.ClrType)
                            .Property<DateTime>(prop.Name)
                            .HasConversion(
                                x => x.ToUniversalTime(),
                                x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
                    }
                    else if (prop.ClrType == typeof(DateTime?))
                    {
                        builder
                            .Entity(entityType.ClrType)
                            .Property<DateTime?>(prop.Name)
                            .HasConversion(
                                x => x.HasValue ? x.Value.ToUniversalTime() : x,
                                x => x.HasValue ? DateTime.SpecifyKind(x.Value, DateTimeKind.Utc) : x);
                    }
                }
            }
        }
    }
}
