using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventEase.Models;

namespace EventEase.Services
{
    public class EventService
    {
        private readonly List<Event> _events = new();

        public IReadOnlyList<Event> GetEvents() => _events;

        public EventService()
        {
            _events.AddRange(new List<Event>
            {
                new Event
                {
                    EventName = "Tech Innovators Summit",
                    EventDate = new DateTime(2025, 10, 15),
                    EventLocation = "Austin, TX"
                },
                new Event
                {
                    EventName = "Blazor Bootcamp",
                    EventDate = new DateTime(2025, 11, 3),
                    EventLocation = "Seattle, WA"
                },
                new Event
                {
                    EventName = "Code & Coffee Meetup",
                    EventDate = new DateTime(2025, 10, 28),
                    EventLocation = "Hattiesburg, MS"
                },
                new Event
                {
                    EventName = "Frontend Futures Expo",
                    EventDate = new DateTime(2025, 12, 5),
                    EventLocation = "Chicago, IL"
                },
                new Event
                {
                    EventName = "Holiday Hackathon",
                    EventDate = new DateTime(2025, 12, 20),
                    EventLocation = "New York, NY"
                }
            });
        }

        public void AddEvent(string eventName, DateTime eventDate, string eventLocation)
        {
            if (!string.IsNullOrWhiteSpace(eventName) && !string.IsNullOrWhiteSpace(eventLocation))
            {
                var newEvent = new Event
                {
                    EventName = eventName,
                    EventDate = eventDate,
                    EventLocation = eventLocation
                };

                _events.Add(newEvent);
            }
        }

        public bool DeleteEventByName(string eventName)
        {
            var targetEvent = _events.FirstOrDefault(e => e.EventName?.Equals(eventName, StringComparison.OrdinalIgnoreCase) == true);
            if (targetEvent != null)
            {
                _events.Remove(targetEvent);
                return true;
            }

            return false;
        }

        public void UpdateEvent(Event updatedEvent)
        {
            var existingEvent = _events.FirstOrDefault(e =>
                e.EventName != null &&
                updatedEvent.EventName != null &&
                e.EventName.Equals(updatedEvent.EventName, StringComparison.OrdinalIgnoreCase));
            if (existingEvent != null)
            {
                existingEvent.EventDate = updatedEvent.EventDate;
                existingEvent.EventLocation = updatedEvent.EventLocation;
            }
        }

        public Task RegisterAttendee(string eventName, string name, string email)
        {
            var targetEvent = _events.FirstOrDefault(e =>
                e.EventName != null &&
                e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));

            if (targetEvent != null &&
                !string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(email))
            {
                targetEvent.Attendees.Add(new Attendee
                {
                    UserName = name,
                    UserEmail = email
                });

                Console.WriteLine($"[EventService] Registered {name} ({email}) for {eventName}");
            }

            return Task.CompletedTask;
        }
    }
}
