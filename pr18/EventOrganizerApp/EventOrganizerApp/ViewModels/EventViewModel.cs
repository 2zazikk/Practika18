using EventOrganizerApp.Commands;
using EventOrganizerApp.Models;
using EventOrganizerApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EventOrganizerApp.ViewModels
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private readonly EventService eventService;

        public ObservableCollection<EventModel> Events { get; set; }

        public ObservableCollection<ParticipantModel> Participants { get; set; }

        private EventModel selectedEvent;

        public EventModel SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        // Имя пользователя
        private string participantName;

        public string ParticipantName
        {
            get => participantName;
            set
            {
                participantName = value;
                OnPropertyChanged(nameof(ParticipantName));
            }
        }

        // Почта пользователя
        private string participantEmail;

        public string ParticipantEmail
        {
            get => participantEmail;
            set
            {
                participantEmail = value;
                OnPropertyChanged(nameof(ParticipantEmail));
            }
        }

        public ICommand RegisterCommand { get; }

        public EventViewModel()
        {
            eventService = new EventService();

            Events = new ObservableCollection<EventModel>(
                eventService.GetEvents());

            Participants = new ObservableCollection<ParticipantModel>();

            RegisterCommand = new RelayCommand(async x => await RegisterAsync());
        }

        private async Task RegisterAsync()
        {
            if (SelectedEvent == null)
            {
                MessageBox.Show("Выберите мероприятие");
                return;
            }

            if (string.IsNullOrWhiteSpace(ParticipantName) ||
                string.IsNullOrWhiteSpace(ParticipantEmail))
            {
                MessageBox.Show("Введите имя и почту");
                return;
            }

            ParticipantModel participant = new ParticipantModel
            {
                Name = ParticipantName,
                Email = ParticipantEmail
            };

            bool result = await eventService
                .RegisterParticipantAsync(SelectedEvent, participant);

            if (result)
            {
                Participants.Add(participant);

                MessageBox.Show(
                    "Регистрация прошла успешно!\nПриглашение отправлено.");

                // Очистка полей
                ParticipantName = "";
                ParticipantEmail = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}