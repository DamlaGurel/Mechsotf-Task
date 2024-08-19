using System;
using MeetingOrganizer.Domain.Entities;
using MeetingOrganizer.Domain.Repositories;
using MeetingOrganizer.Infrastructure.Context;

namespace MeetingOrganizer.Infrastructure.Repositories
{
	public class MeetingRepository:BaseRepository<Meeting>,IMeetingRepository
	{
		public MeetingRepository(AppDbContext context):base(context)
		{
		}
	}
}

