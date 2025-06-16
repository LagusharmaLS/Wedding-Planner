using Microsoft.AspNetCore.Mvc;
using DreamDays.Models;

namespace DreamDays.Controllers
{
    public class CoupleController : Controller
    {
        public IActionResult Dashboard()
        {
            var deadlines = new List<Deadline>
            {
                new Deadline { Id = 1, TaskName = "Book Venue", DueDate = DateTime.Now.AddDays(10) },
                new Deadline { Id = 2, TaskName = "Send Invitations", DueDate = DateTime.Now.AddDays(20) }
            };

            var vendors = new List<Vendor>
            {
                new Vendor
                {
                    Id = 1,
                    Name = "Dream Venue",
                    Category = "Venue",
                    Location = "New York",
                    Price = 5000,
                    Availability = "Available",
                    Description = "A beautiful venue for your wedding",
                    Rating = 4.5,
                    ContactInfo = "contact@dreamvenue.com",
                    IsFavorite = false,
                    Reviews = new List<Review>
                    {
                        new Review { Comment = "Amazing place!", Rating = 4.5 }
                    }
                },
                new Vendor
                {
                    Id = 2,
                    Name = "Tasty Catering",
                    Category = "Catering",
                    Location = "Los Angeles",
                    Price = 3000,
                    Availability = "Booked",
                    Description = "Delicious catering services",
                    Rating = 4.0,
                    ContactInfo = "contact@tastycatering.com",
                    IsFavorite = true,
                    Reviews = new List<Review>
                    {
                        new Review { Comment = "Great food!", Rating = 4.0 }
                    }
                }
            };

            var model = new CoupleDashboardViewModel(
                taskCompletionPercentage: (int)60.0,
                totalBudget: 50000,
                fundsAllocated: 40000,
                fundsSpent: 30000,
                upcomingDeadlineIds: deadlines.Select(d => d.Id).ToList(),
                upcomingDeadlineTaskNames: deadlines.Select(d => d.TaskName).ToList(),
                upcomingDeadlineDueDates: deadlines.Select(d => d.DueDate).ToList(),
                guestIds: new List<int> { 1, 2 },
                guestNames: new List<string> { "John Doe", "Jane Smith" },
                guestEmails: new List<string> { "john@example.com", "jane@example.com" },
                guestPhones: new List<string> { "123-456-7890", "098-765-4321" },
                guestRelationships: new List<string> { "Friend", "Family" },
                guestRSVPStatuses: new List<string> { "Accepted", "Pending" },
                guestMealPreferences: new List<string> { "Vegetarian", "Non-Vegetarian" },
                guestSeatingAssignments: new List<string> { "Table 1", "Table 2" },
                timelineEventIds: new List<int> { 1, 2 },
                timelineEventNames: new List<string> { "Ceremony", "Reception" },
                timelineEventStartTimes: new List<DateTime> { DateTime.Now.AddDays(30), DateTime.Now.AddDays(30).AddHours(2) },
                timelineEventEndTimes: new List<DateTime> { DateTime.Now.AddDays(30).AddHours(1), DateTime.Now.AddDays(30).AddHours(4) },
                vendors: vendors
            );

            return View(model);
        }

        // Placeholder actions for navigation (implement as needed)
        public IActionResult CoupleChecklist() => View();
        public IActionResult CoupleGuestList() => View();
        public IActionResult CoupleBudgetTracker() => View();
        public IActionResult CoupleTimeline() => View();
        public IActionResult CoupleVendors() => View();
        public IActionResult SaveDashboardLayout(List<string> widgetOrder) => Json(new { success = true });
        public IActionResult GetVendorReviews(int vendorId)
        {
            var reviews = new List<object>
            {
                new { comment = "Great service!", rating = 4.5 },
                new { comment = "Highly recommend!", rating = 5.0 }
            };
            return Json(new { reviews });
        }
        public IActionResult AddTimelineEvent(string eventName, DateTime startTime, DateTime endTime) => Json(new { success = true, eventId = 3 });
        public IActionResult UpdateTimelineEvent(int id, string eventName, DateTime startTime, DateTime endTime) => Json(new { success = true });
        public IActionResult DeleteTimelineEvent(int id) => Json(new { success = true });
        public IActionResult ShareTimeline(List<object> timeline) => Json(new { success = true });
        public IActionResult SendNotification(string message) => Json(new { success = true });
        public IActionResult AddBudgetCategory(string category, decimal allocatedAmount, decimal spentAmount) => Json(new { success = true, categoryId = 1 });
        public IActionResult UpdateBudgetCategory(int id, string category, decimal allocatedAmount, decimal spentAmount) => Json(new { success = true });
        public IActionResult DeleteBudgetCategory(int id) => Json(new { success = true });
        public IActionResult AddGuest(string name, string email, string phone, string relationship, string rsvpStatus, string mealPreference, string seatingAssignment) => Json(new { success = true, guestId = 3 });
        public IActionResult UpdateGuest(int id, string name, string email, string phone, string relationship, string rsvpStatus, string mealPreference, string seatingAssignment) => Json(new { success = true });
        public IActionResult DeleteGuest(int id) => Json(new { success = true });
        public IActionResult ImportGuests(List<object> guests) => Json(new { success = true, guestIds = new List<int> { 3, 4 } });
        public IActionResult SendRsvpReminders(List<string> emails) => Json(new { success = true });
    }
}