using System;
using AutoMapper;
using MeetingOrganizer.Domain.Entities;
using MeetingOrganizer.Models.DTOs;

namespace MeetingOrganizer.Application.AutoMapper
{
	public class Mapping:Profile
	{
		public Mapping()
		{
			CreateMap<Meeting, CreateMeetingDto>().ReverseMap();
            CreateMap<Meeting, ListMeetingDto>() .ReverseMap();
            CreateMap<Meeting, UpdateMeetingDto>().ReverseMap();
            CreateMap<Meeting, DetailMeetingDto>().ReverseMap();

        }
    }
}

