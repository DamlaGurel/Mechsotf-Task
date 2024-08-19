using System;
using MeetingOrganizer.Domain.Enums;

namespace MeetingOrganizer.Models.DTOs
{
	public class CreateMeetingDto
	{
        public string? MeetingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string? Participants { get; set; }
        public DateTime? CreatedDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}

