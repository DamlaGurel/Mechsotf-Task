using System;
using MeetingOrganizer.Domain.Entities;
using MeetingOrganizer.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MeetingOrganizer.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MeetingConfiguration());

            base.OnModelCreating(builder);
        }
    }
}

