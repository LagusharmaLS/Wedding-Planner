namespace DreamDays.Models
{
    public class AdminDashboardViewModel
    {
        public List<User>? Users { get; set; } // References existing User class
        public List<Vendor>? Vendors { get; set; } // References existing Vendor class
        public List<Couple>? Couples { get; set; } // Added for CoupleManagement.cshtml
        public int WeddingCount { get; set; }
        public int VendorCount { get; set; }
        public int CompletedWeddingCount { get; set; } // Added for AdminDashboard.cshtml
    }

    public class Couple
    {
        public int Id { get; set; }
        public string Partner1Name { get; set; } = string.Empty;
        public string Partner2Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime WeddingDate { get; set; }
    }
}