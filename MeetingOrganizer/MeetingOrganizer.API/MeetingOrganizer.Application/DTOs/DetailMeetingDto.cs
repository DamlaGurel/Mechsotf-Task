using System;
namespace MeetingOrganizer.Models.DTOs
{
	public class DetailMeetingDto
	{
        public int Id { get; set; }
        public string? MeetingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string? Participants { get; set; }
    }
}

