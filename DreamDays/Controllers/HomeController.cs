using Microsoft.AspNetCore.Mvc;
using DreamDays.Models; // Make sure to include this for all your entities like WeddingEntity and ChecklistItemEntity
using DreamDays.Data;   // Add this for DbContext
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamDays.Controllers
{
    public class HomeController : Controller
    {
        private readonly DreamDaysDbContext _context;

        public HomeController(DreamDaysDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CoupleDashboard()
        {
            var vendors = new List<Vendor>
            {
                new Vendor
                {
                    Id = 1,
                    Name = "Elegant Venues",
                    Category = "Venue",
                    Location = "New York, NY",
                    Price = 15000,
                    Availability = "Available",
                    Description = "Beautiful venue for weddings with elegant decor",
                    Rating = 4.5,
                    ContactInfo = "contact@elegantvenues.com",
                    IsFavorite = false,
                    Reviews = new List<Review> { new Review { Id = 1, Comment = "Amazing venue, perfect for our wedding!", Rating = 4.5 } }
                },
                new Vendor
                {
                    Id = 2,
                    Name = "Tasty Catering",
                    Category = "Catering",
                    Location = "Los Angeles, CA",
                    Price = 5000,
                    Availability = "Booked",
                    Description = "Delicious wedding catering with customizable menus",
                    Rating = 4.0,
                    ContactInfo = "contact@tastycatering.com",
                    IsFavorite = true,
                    Reviews = new List<Review> { new Review { Id = 2, Comment = "Great food and service!", Rating = 4.0 } }
                },
                new Vendor
                {
                    Id = 3,
                    Name = "Bloom Florist",
                    Category = "Florist",
                    Location = "Chicago, IL",
                    Price = 2000,
                    Availability = "Available",
                    Description = "Stunning floral arrangements for weddings",
                    Rating = 4.8,
                    ContactInfo = "contact@bloomflorist.com",
                    IsFavorite = false,
                    Reviews = new List<Review> { new Review { Id = 3, Comment = "Beautiful flowers!", Rating = 4.8 } }
                }
            };

            var model = new CoupleDashboardViewModel(
                taskCompletionPercentage: 60,
                totalBudget: 50000,
                fundsAllocated: 40000,
                fundsSpent: 30000,
                upcomingDeadlineIds: new List<int> { 1, 2 },
                upcomingDeadlineTaskNames: new List<string> { "Book Venue", "Send Invitations" },
                upcomingDeadlineDueDates: new List<DateTime> { DateTime.Now.AddDays(7), DateTime.Now.AddDays(14) },
                checklistIds: new List<int> { 1, 2 },
                checklistDescriptions: new List<string> { "Book Venue", "Send Invitations" },
                checklistDeadlines: new List<DateTime> { DateTime.Now.AddDays(7), DateTime.Now.AddDays(14) },
                checklistIsCompleted: new List<bool> { false, true },
                guestIds: new List<int> { 1, 2 },
                guestNames: new List<string> { "John Doe", "Jane Smith" },
                guestEmails: new List<string> { "john@example.com", "jane@example.com" },
                guestPhones: new List<string> { "123-456-7890", "098-765-4321" },
                guestRelationships: new List<string> { "Friend", "Family" },
                guestRSVPStatuses: new List<string> { "Accepted", "Pending" },
                guestMealPreferences: new List<string> { "Vegetarian", "Gluten-Free" },
                guestSeatingAssignments: new List<string> { "Table 1", "Table 2" },
                budgetCategoryIds: new List<int> { 1, 2, 3 },
                budgetCategoryCategories: new List<string> { "Venue", "Catering", "Photography" },
                budgetCategoryAllocatedAmounts: new List<decimal> { 20000, 10000, 5000 },
                budgetCategorySpentAmounts: new List<decimal> { 18000, 12000, 4500 },
                timelineEventIds: new List<int> { 1, 2 },
                timelineEventNames: new List<string> { "Ceremony", "Reception" },
                timelineEventStartTimes: new List<DateTime> { DateTime.Now.AddHours(1), DateTime.Now.AddHours(3) },
                timelineEventEndTimes: new List<DateTime> { DateTime.Now.AddHours(2), DateTime.Now.AddHours(5) },
                vendors: vendors
            );
            ViewData["ActivePage"] = "Dashboard";
            return View("~/Views/CoupleDashboard/Dashboard.cshtml", model);
        }

        public IActionResult CoupleChecklist()
        {
            var model = new CoupleDashboardViewModel(
                checklistIds: new List<int> { 1, 2, 3 },
                checklistDescriptions: new List<string> { "Book Venue", "Send Invitations", "Choose Caterer" },
                checklistDeadlines: new List<DateTime> { DateTime.Now.AddDays(7), DateTime.Now.AddDays(14), DateTime.Now.AddDays(10) },
                checklistIsCompleted: new List<bool> { false, true, false }
            );
            ViewData["ActivePage"] = "Checklist";
            return View("~/Views/CoupleDashboard/Checklist.cshtml", model);
        }

        public IActionResult CoupleGuestList()
        {
            var model = new CoupleDashboardViewModel(
                guestIds: new List<int> { 1, 2, 3 },
                guestNames: new List<string> { "John Doe", "Jane Smith", "Bob Johnson" },
                guestEmails: new List<string> { "john@example.com", "jane@example.com", "bob@example.com" },
                guestPhones: new List<string> { "123-456-7890", "098-765-4321", "555-555-5555" },
                guestRelationships: new List<string> { "Friend", "Family", "Colleague" },
                guestRSVPStatuses: new List<string> { "Accepted", "Pending", "Declined" },
                guestMealPreferences: new List<string> { "Vegetarian", "Gluten-Free", "None" },
                guestSeatingAssignments: new List<string> { "Table 1", "Table 2", "None" }
            );
            ViewData["ActivePage"] = "GuestList";
            return View("~/Views/CoupleDashboard/GuestList.cshtml", model);
        }

        public IActionResult CoupleBudgetTracker()
        {
            var model = new CoupleDashboardViewModel(
                totalBudget: 50000,
                fundsAllocated: 40000,
                fundsSpent: 30000,
                budgetCategoryIds: new List<int> { 1, 2, 3 },
                budgetCategoryCategories: new List<string> { "Venue", "Catering", "Photography" },
                budgetCategoryAllocatedAmounts: new List<decimal> { 20000, 10000, 5000 },
                budgetCategorySpentAmounts: new List<decimal> { 18000, 12000, 4500 }
            );
            ViewData["ActivePage"] = "BudgetTracker";
            return View("~/Views/CoupleDashboard/BudgetTracker.cshtml", model);
        }

        public IActionResult CoupleTimeline()
        {
            var model = new CoupleDashboardViewModel(
                timelineEventIds: new List<int> { 1, 2, 3 },
                timelineEventNames: new List<string> { "Ceremony", "Reception", "First Dance" },
                timelineEventStartTimes: new List<DateTime> { DateTime.Now.AddHours(1), DateTime.Now.AddHours(3), DateTime.Now.AddHours(4) },
                timelineEventEndTimes: new List<DateTime> { DateTime.Now.AddHours(2), DateTime.Now.AddHours(5), DateTime.Now.AddHours(4.5) }
            );
            ViewData["ActivePage"] = "Timeline";
            return View("~/Views/CoupleDashboard/Timeline.cshtml", model);
        }

        public IActionResult CoupleVendors()
        {
            var vendorEntities = _context.Vendors.ToList();
            var vendors = vendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new CoupleDashboardViewModel(vendors: vendors);
            ViewData["ActivePage"] = "Vendors";
            return View("~/Views/CoupleDashboard/Vendors.cshtml", model);
        }

        [HttpGet]
        public IActionResult FilterVendors(string searchName, string category, string location, string priceRange, string availability)
        {
            var vendors = _context.Vendors.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                vendors = vendors.Where(v => v.Name != null && v.Name.ToLower().Contains(searchName.ToLower()));
            }

            if (!string.IsNullOrEmpty(category))
            {
                vendors = vendors.Where(v => v.Category != null && v.Category.ToLower() == category.ToLower());
            }

            if (!string.IsNullOrEmpty(location))
            {
                vendors = vendors.Where(v => v.Location != null && v.Location.ToLower() == location.ToLower());
            }

            if (!string.IsNullOrEmpty(availability))
            {
                vendors = vendors.Where(v => v.Availability != null && v.Availability.ToLower() == availability.ToLower());
            }

            if (!string.IsNullOrEmpty(priceRange))
            {
                if (priceRange == "10000+")
                {
                    vendors = vendors.Where(v => v.Price >= 10000);
                }
                else
                {
                    var range = priceRange.Split('-').Select(int.Parse).ToArray();
                    var min = range[0];
                    var max = range[1];
                    vendors = vendors.Where(v => v.Price >= min && v.Price <= max);
                }
            }

            var filteredVendorEntities = vendors.ToList();
            var filteredVendors = filteredVendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new CoupleDashboardViewModel(vendors: filteredVendors);
            return PartialView("~/Views/Shared/_VendorListPartial.cshtml", model);
        }

        public IActionResult PlannerDashboard()
        {
            var weddings = _context.Weddings.ToList();
            var checklistItems = _context.ChecklistItems.ToList();
            var vendorEntities = _context.Vendors.ToList();
            var messages = _context.Messages.ToList();
            var logisticsTasks = _context.LogisticsTasks.ToList();

            var vendors = vendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new CoupleDashboardViewModel(
                weddingIds: weddings.Select(w => w.Id).ToList(),
                weddingCoupleNames: weddings.Select(w => w.CoupleName).ToList(),
                weddingDates: weddings.Select(w => w.Date).ToList(),
                weddingStatuses: weddings.Select(w => w.Status).ToList(),
                weddingBudgets: weddings.Select(w => w.Budget).ToList(),
                weddingLocations: weddings.Select(w => w.Location).ToList(),
                checklistIds: checklistItems.Select(c => c.Id).ToList(),
                checklistDescriptions: checklistItems.Select(c => c.Description).ToList(),
                checklistDeadlines: checklistItems.Select(c => c.Deadline).ToList(),
                checklistIsCompleted: checklistItems.Select(c => c.IsCompleted).ToList(),
                vendors: vendors,
                messageIds: messages.Select(m => m.Id).ToList(),
                messageSenders: messages.Select(m => m.Sender).ToList(),
                messageReceivers: messages.Select(m => m.Receiver).ToList(),
                messageContents: messages.Select(m => m.Content).ToList(),
                messageTimestamps: messages.Select(m => m.Timestamp).ToList(),
                messageIsRead: messages.Select(m => m.IsRead).ToList(),
                logisticsTaskIds: logisticsTasks.Select(t => t.Id).ToList(),
                logisticsTaskTypes: logisticsTasks.Select(t => t.TaskType).ToList(),
                logisticsTaskDescriptions: logisticsTasks.Select(t => t.Description).ToList(),
                logisticsTaskScheduledTimes: logisticsTasks.Select(t => t.ScheduledTime).ToList(),
                logisticsTaskStatuses: logisticsTasks.Select(t => t.Status).ToList()
            );
            ViewData["ActivePage"] = "PlannerDashboard";
            return View("~/Views/Planner/Dashboard.cshtml", model);
        }

        [HttpPost]
        public IActionResult AddWedding(string coupleName, DateTime date, string status, decimal budget, string location)
        {
            var wedding = new DreamDaysDbContext.WeddingEntity
            {
                CoupleName = coupleName,
                Date = date,
                Status = status,
                Budget = budget,
                Location = location
            };
            _context.Weddings.Add(wedding);
            _context.SaveChanges();

            return Json(new { success = true, weddingId = wedding.Id });
        }

        [HttpPost]
        public IActionResult UpdateWedding(int id, string coupleName, DateTime date, string status, decimal budget, string location)
        {
            var wedding = _context.Weddings.Find(id);
            if (wedding == null)
            {
                return Json(new { success = false, message = "Wedding not found." });
            }

            wedding.CoupleName = coupleName;
            wedding.Date = date;
            wedding.Status = status;
            wedding.Budget = budget;
            wedding.Location = location;

            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult DeleteWedding(int id)
        {
            var wedding = _context.Weddings.Find(id);
            if (wedding == null)
            {
                return Json(new { success = false, message = "Wedding not found." });
            }

            _context.Weddings.Remove(wedding);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult AddChecklistItem(string description, DateTime deadline, bool isCompleted)
        {
            var checklistItem = new DreamDaysDbContext.ChecklistItemEntity
            {
                Description = description,
                Deadline = deadline,
                IsCompleted = isCompleted
            };
            _context.ChecklistItems.Add(checklistItem);
            _context.SaveChanges();

            return Json(new { success = true, checklistId = checklistItem.Id });
        }

        [HttpPost]
        public IActionResult UpdateChecklistItem(int id, string description, DateTime deadline, bool isCompleted)
        {
            var checklistItem = _context.ChecklistItems.Find(id);
            if (checklistItem == null)
            {
                return Json(new { success = false, message = "Checklist item not found." });
            }

            checklistItem.Description = description;
            checklistItem.Deadline = deadline;
            checklistItem.IsCompleted = isCompleted;

            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult DeleteChecklistItem(int id)
        {
            var checklistItem = _context.ChecklistItems.Find(id);
            if (checklistItem == null)
            {
                return Json(new { success = false, message = "Checklist item not found." });
            }

            _context.ChecklistItems.Remove(checklistItem);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult PlannerMessages()
        {
            var messages = _context.Messages.ToList();
            var model = new CoupleDashboardViewModel(
                messageIds: messages.Select(m => m.Id).ToList(),
                messageSenders: messages.Select(m => m.Sender).ToList(),
                messageReceivers: messages.Select(m => m.Receiver).ToList(),
                messageContents: messages.Select(m => m.Content).ToList(),
                messageTimestamps: messages.Select(m => m.Timestamp).ToList(),
                messageIsRead: messages.Select(m => m.IsRead).ToList()
            );
            ViewData["ActivePage"] = "Messages";
            return View("~/Views/Planner/Messages.cshtml", model);
        }

        public IActionResult PlannerReports()
        {
            var model = new CoupleDashboardViewModel(
                popularVenueNames: new List<string> { "Elegant Venues", "Galle Face Hotel", "Shangri-La Colombo" },
                popularVenueCounts: new List<int> { 10, 8, 5 },
                budgetTrendMonths: new List<string> { "Jan", "Feb", "Mar", "Apr", "May" },
                budgetTrendAverageBudgets: new List<decimal> { 45000, 47000, 48000, 50000, 52000 },
                vendorPerformanceVendorNames: new List<string> { "Elegant Venues", "Tasty Catering", "Bloom Florist" },
                vendorPerformanceAverageRatings: new List<double> { 4.5, 4.0, 4.8 },
                vendorPerformanceBookingCounts: new List<int> { 10, 8, 5 }
            );
            ViewData["ActivePage"] = "Reports";
            return View("~/Views/Planner/Reports.cshtml", model);
        }

        public IActionResult AdminDashboard()
        {
            var vendorEntities = _context.Vendors.ToList();
            var vendors = vendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new AdminDashboardViewModel
            {
                Users = _context.Users.ToList(),
                Vendors = vendors,
                Couples = new List<Couple>
                {
                    new() { Id = 1, Partner1Name = "John", Partner2Name = "Jane", Email = "john.jane@example.com", WeddingDate = DateTime.Now.AddMonths(6) },
                    new() { Id = 2, Partner1Name = "Alice", Partner2Name = "Bob", Email = "alice.bob@example.com", WeddingDate = DateTime.Now.AddMonths(8) }
                },
                WeddingCount = 2,
                VendorCount = 3,
                CompletedWeddingCount = 1
            };
            ViewData["ActivePage"] = "AdminDashboard";
            return View("~/Views/Admin/Dashboard.cshtml", model);
        }

        public IActionResult CoupleManagement()
        {
            var vendorEntities = _context.Vendors.ToList();
            var vendors = vendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new AdminDashboardViewModel
            {
                Users = _context.Users.ToList(),
                Vendors = vendors,
                Couples = new List<Couple>
                {
                    new() { Id = 1, Partner1Name = "John", Partner2Name = "Jane", Email = "john.jane@example.com", WeddingDate = DateTime.Now.AddMonths(6) },
                    new() { Id = 2, Partner1Name = "Alice", Partner2Name = "Bob", Email = "alice.bob@example.com", WeddingDate = DateTime.Now.AddMonths(8) }
                },
                WeddingCount = 2,
                VendorCount = 3,
                CompletedWeddingCount = 1
            };
            ViewData["ActivePage"] = "CoupleManagement";
            return View("~/Views/Admin/CoupleManagement.cshtml", model);
        }

        public IActionResult VendorsManagement()
        {
            var vendorEntities = _context.Vendors.ToList();
            var vendors = vendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new AdminDashboardViewModel
            {
                Users = _context.Users.ToList(),
                Vendors = vendors,
                Couples = new List<Couple>
                {
                    new() { Id = 1, Partner1Name = "John", Partner2Name = "Jane", Email = "john.jane@example.com", WeddingDate = DateTime.Now.AddMonths(6) },
                    new() { Id = 2, Partner1Name = "Alice", Partner2Name = "Bob", Email = "alice.bob@example.com", WeddingDate = DateTime.Now.AddMonths(8) }
                },
                WeddingCount = 2,
                VendorCount = 3,
                CompletedWeddingCount = 1
            };
            ViewData["ActivePage"] = "VendorsManagement";
            return View("~/Views/Admin/VendorsManagement.cshtml", model);
        }

        public IActionResult SystemUsage()
        {
            var vendorEntities = _context.Vendors.ToList();
            var vendors = vendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new AdminDashboardViewModel
            {
                Users = _context.Users.ToList(),
                Vendors = vendors,
                Couples = new List<Couple>
                {
                    new() { Id = 1, Partner1Name = "John", Partner2Name = "Jane", Email = "john.jane@example.com", WeddingDate = DateTime.Now.AddMonths(6) },
                    new() { Id = 2, Partner1Name = "Alice", Partner2Name = "Bob", Email = "alice.bob@example.com", WeddingDate = DateTime.Now.AddMonths(8) }
                },
                WeddingCount = 2,
                VendorCount = 3,
                CompletedWeddingCount = 1
            };
            ViewData["ActivePage"] = "SystemUsage";
            return View("~/Views/Admin/SystemUsage.cshtml", model);
        }

        public IActionResult Reports()
        {
            var vendorEntities = _context.Vendors.ToList();
            var vendors = vendorEntities.Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name,
                Category = v.Category,
                Location = v.Location,
                Price = v.Price,
                Availability = v.Availability,
                Description = v.Description,
                Rating = v.Rating,
                ContactInfo = v.ContactInfo,
                IsFavorite = v.IsFavorite,
                Reviews = v.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            var model = new AdminDashboardViewModel
            {
                Users = _context.Users.ToList(),
                Vendors = vendors,
                Couples = new List<Couple>
                {
                    new() { Id = 1, Partner1Name = "John", Partner2Name = "Jane", Email = "john.jane@example.com", WeddingDate = DateTime.Now.AddMonths(6) },
                    new() { Id = 2, Partner1Name = "Alice", Partner2Name = "Bob", Email = "alice.bob@example.com", WeddingDate = DateTime.Now.AddMonths(8) }
                },
                WeddingCount = 2,
                VendorCount = 3,
                CompletedWeddingCount = 1
            };
            ViewData["ActivePage"] = "Reports";
            return View("~/Views/Admin/Reports.cshtml", model);
        }

        public IActionResult VendorDashboard()
        {
            ViewData["ActivePage"] = "Dashboard";
            return View("~/Views/Vendor/Dashboard.cshtml");
        }

        public IActionResult VendorCatalog()
        {
            ViewData["ActivePage"] = "Catalog";
            return View("~/Views/Vendor/Catalog.cshtml");
        }

        public IActionResult GuestDashboard()
        {
            ViewData["ActivePage"] = "Dashboard";
            return View("~/Views/Guest/Dashboard.cshtml");
        }

        public IActionResult GuestRSVP()
        {
            ViewData["ActivePage"] = "RSVP";
            return View("~/Views/Guest/RSVP.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Auth");
        }
    }
}