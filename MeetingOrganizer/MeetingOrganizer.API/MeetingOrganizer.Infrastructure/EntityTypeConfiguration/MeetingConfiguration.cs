using System;
using MeetingOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingOrganizer.Infrastructure.EntityTypeConfiguration
{
	public class MeetingConfiguration:IEntityTypeConfiguration<Meeting>
	{
		public void Configure(EntityTypeBuilder<Meeting> builder)
		{
            builder.HasKey(x => x.Id);
        }
	}
}

