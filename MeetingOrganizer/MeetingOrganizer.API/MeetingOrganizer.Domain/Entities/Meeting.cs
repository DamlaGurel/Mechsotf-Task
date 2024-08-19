using System;
using MeetingOrganizer.Domain.Enums;

namespace MeetingOrganizer.Domain.Entities
{
	public class Meeting :IBaseEntity
    {
		public int? Id { get; set; }
		public string? MeetingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string? Participants { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status? Status { get; set; }
    }
}

