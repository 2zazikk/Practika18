using EventOrganizerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventOrganizerApp.Services
{
    public class EventService
    {
        // Асинхронная регистрация
        public async Task<bool> RegisterParticipantAsync(
            EventModel eventModel,
            ParticipantModel participant)
        {
            // Имитация отправки приглашения
            await Task.Delay(3000);

            return true;
        }

        // Получение списка мероприятий
        public List<EventModel> GetEvents()
        {
            return new List<EventModel>
            {
                new EventModel
                {
                    Title = "Конференция IT",
                    Date = System.DateTime.Now,
                    Description = "Конференция для разработчиков"
                },

                new EventModel
                {
                    Title = "Встреча GameDev",
                    Date = System.DateTime.Now.AddDays(2),
                    Description = "Встреча разработчиков игр"
                },

                new EventModel
                {
                    Title = "Хакатон",
                    Date = System.DateTime.Now.AddDays(5),
                    Description = "Командное соревнование программистов"
                }
            };
        }
    }
}