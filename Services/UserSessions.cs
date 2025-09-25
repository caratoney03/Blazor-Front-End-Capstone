namespace EventEase.Services
{
    public class UserSessions
    {
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public List<string> RegisteredEvents { get; set; } = new();

        public void Register(string EventName)
        {
            if (!RegisteredEvents.Contains(EventName))
            {
                RegisteredEvents.Add(EventName);
            }
        }

        public void ClearSession()
        {
            UserName = string.Empty;
            UserEmail = string.Empty;
            RegisteredEvents.Clear();
        }

        public bool IsSignedUp => !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(UserEmail);
    }
}
