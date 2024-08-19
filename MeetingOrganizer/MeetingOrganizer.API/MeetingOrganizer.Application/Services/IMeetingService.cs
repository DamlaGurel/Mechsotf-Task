using System;
using MeetingOrganizer.Domain.Entities;
using MeetingOrganizer.Models.DTOs;

namespace MeetingOrganizer.Models.Services
{
	public interface IMeetingService
	{
        /// <summary>
        /// Yeni bir Meeting oluşturmak için kullanılan asenkron metot.
        /// </summary>
        /// <param name="CreateMeetingDto"></param>
        /// <returns> CreateMeetingDto döndürür.</returns>
        Task<CreateMeetingDto> CreateMeeting(CreateMeetingDto model);
        /// <summary>
        /// Bir Meeting güncellemek için kullanılan asenkron metot.
        /// </summary>
        /// <param name="UpdateMeetingDto">id ve updatemeetingdto parametreleri</param>
        /// <returns>UpdateMeetingDto döndürür.</returns>
        Task<Meeting> UpdateMeeting(UpdateMeetingDto model,int id);
        /// <summary>
        /// Meeting status'ü passive'e geçerek soft delete yapan asenkron metot.
        /// </summary>
        /// <param name="id">Silinecek Meeting Id'si int cinsinden.</param>
        /// <returns>Değer döndürmeyen metot.</returns>
		Task SoftDeleteMeeting(int id);
        /// <summary>
        /// Veritabanındaki status'u passive olmayan tüm Meeting'leri getiren asenkron metot.
        /// </summary>
        /// <returns>List(ListMeetingDto) döndürür.</returns>
        Task<List<ListMeetingDto>> GetMeetingList();

        /// <summary>
        /// Meeting'ler içinden Id'sine göre meeting getiren asenkron metot.
        /// </summary>
        /// <param name="id">İstenen Meeting Id'si int cinsinden</param>
        /// <returns>DetailMeetingDto döndürür.</returns>
		Task<DetailMeetingDto> GetMeetingById(int id);

	}
}

