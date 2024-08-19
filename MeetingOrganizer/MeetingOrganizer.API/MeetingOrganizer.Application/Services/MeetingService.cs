using System;
using AutoMapper;
using MeetingOrganizer.Domain.Entities;
using MeetingOrganizer.Domain.Enums;
using MeetingOrganizer.Domain.Repositories;
using MeetingOrganizer.Models.DTOs;

namespace MeetingOrganizer.Models.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepo;
        private readonly IMapper _mapper;



        public MeetingService(IMeetingRepository meetingRepo, IMapper mapper)
        {
            _meetingRepo = meetingRepo;
            _mapper = mapper;
        }

        public async Task<CreateMeetingDto> CreateMeeting(CreateMeetingDto model)
        {
            var meeting = _mapper.Map<Meeting>(model);
            await _meetingRepo.Create(meeting);
            return _mapper.Map<CreateMeetingDto>(meeting);

        }

        public async Task<DetailMeetingDto> GetMeetingById(int id)
        {

            var meeting = await _meetingRepo.GetFilteredFirstOrDefault(select: x => _mapper.Map<DetailMeetingDto>(x), where: m => m.Id.Equals(id) && m.Status != Status.Passive);

            return meeting;
        }

        public async Task<List<ListMeetingDto>> GetMeetingList()
        {
            var meetings = await _meetingRepo.GetFilteredList(select: x => _mapper.Map<Meeting>(x), where: x => x.Status != Status.Passive);
            var meetingList = _mapper.Map<List<ListMeetingDto>>(meetings);
     

           

            return meetingList;
        }

        public async Task SoftDeleteMeeting(int id)
        {

            var meeting = await _meetingRepo.GetDefault(x => x.Id == id);

            meeting.Status = Status.Passive;
            meeting.DeletedDate = DateTime.Now;
            await _meetingRepo.SoftDelete(meeting);
        }

        public async Task<Meeting> UpdateMeeting(UpdateMeetingDto model,int id)
        {
            var meeting = await _meetingRepo.GetDefault(x => x.Id == id);
            meeting.MeetingDescription = model.MeetingDescription;
            meeting.MeetingDate = model.MeetingDate;
            meeting.StartTime = model.StartTime;
            meeting.EndTime= model.EndTime;
            meeting.Participants = model.Participants;
            meeting.UpdatedDate = DateTime.Now;
            meeting.Status = Status.Modified;


          await _meetingRepo.Update(meeting);
            return meeting;
        }
    }
}

