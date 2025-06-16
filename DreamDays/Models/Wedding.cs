using System;

namespace DreamDays.Models.SubModels
{
    public class Wedding
    {
        public int Id { get; set; }
        public string CoupleName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}