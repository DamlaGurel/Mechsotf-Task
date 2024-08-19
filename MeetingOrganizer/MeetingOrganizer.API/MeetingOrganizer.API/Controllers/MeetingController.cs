using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingOrganizer.Domain.Entities;
using MeetingOrganizer.Models.DTOs;
using MeetingOrganizer.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeetingOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

       

        [HttpPost]
        [Route("CreateMeeting")]
        public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingDto createMeeting)
        {
            await _meetingService.CreateMeeting(createMeeting);
            return Ok("Created New Meeting!");
            
        }

        [HttpPut]
        [Route("UpdateMeeting/{id}")]
        public async Task<IActionResult> UpdateMeeting([FromBody] UpdateMeetingDto updateMeeting,int id)
        {
           
            await _meetingService.UpdateMeeting(updateMeeting,id);
            return Ok("Updated Meeting!");
                
        }

        [HttpDelete]
        [Route("DeleteSiteManager/{id}")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            await _meetingService.SoftDeleteMeeting(id);
            return Ok("Deleted Meeting!");
        }

        [HttpGet]
        [Route("GetMeetingDetails/{id}")]
        public async Task<IActionResult> GetMeetingDetails(int id )
        {
           var meeting=  await _meetingService.GetMeetingById(id);
            return Ok(meeting);
        }

        [HttpGet]
        [Route("GetMeetingList")]
        public async Task<List<ListMeetingDto>> GetMeetingList()
        {
            var meetingList = await _meetingService.GetMeetingList();
            return meetingList;
        }



    }
}