namespace DreamDays.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Made nullable to resolve CS8618
        public string? Email { get; set; } // Made nullable to resolve CS8618
        public string? Role { get; set; } // Made nullable to resolve CS8618
        public string? Password { get; set; } // Added for AuthController
        public bool IsMFAEnabled { get; set; } // Added for AuthController
        public string? WeddingEventId { get; set; } // Added for AuthController
    }
}