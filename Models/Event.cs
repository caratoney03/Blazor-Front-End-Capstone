namespace EventEase.Models
{
    public class Event
    {
        public string? EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventLocation { get; set; }

        public List<Attendee> Attendees { get; set; } = new();
    }
}
