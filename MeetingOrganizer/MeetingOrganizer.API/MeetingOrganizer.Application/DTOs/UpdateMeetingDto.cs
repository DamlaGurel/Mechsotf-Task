﻿using System;
using MeetingOrganizer.Domain.Enums;

namespace MeetingOrganizer.Models.DTOs
{
	public class UpdateMeetingDto
	{
        public string? MeetingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string? Participants { get; set; }
       
    }
}

