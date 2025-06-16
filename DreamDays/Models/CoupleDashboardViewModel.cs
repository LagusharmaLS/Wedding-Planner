using System;
using System.Collections.Generic;

namespace DreamDays.Models
{
    public class CoupleDashboardViewModel(
        int taskCompletionPercentage = 0,
        decimal totalBudget = 0,
        decimal fundsAllocated = 0,
        decimal fundsSpent = 0,
        List<int>? upcomingDeadlineIds = null,
        List<string>? upcomingDeadlineTaskNames = null,
        List<DateTime>? upcomingDeadlineDueDates = null,
        List<int>? checklistIds = null,
        List<string>? checklistDescriptions = null,
        List<DateTime>? checklistDeadlines = null,
        List<bool>? checklistIsCompleted = null,
        List<int>? guestIds = null,
        List<string>? guestNames = null,
        List<string>? guestEmails = null,
        List<string>? guestPhones = null,
        List<string>? guestRelationships = null,
        List<string>? guestRSVPStatuses = null,
        List<string>? guestMealPreferences = null,
        List<string>? guestSeatingAssignments = null,
        List<int>? budgetCategoryIds = null,
        List<string>? budgetCategoryCategories = null,
        List<decimal>? budgetCategoryAllocatedAmounts = null,
        List<decimal>? budgetCategorySpentAmounts = null,
        List<int>? timelineEventIds = null,
        List<string>? timelineEventNames = null,
        List<DateTime>? timelineEventStartTimes = null,
        List<DateTime>? timelineEventEndTimes = null,
        List<int>? weddingIds = null,
        List<string>? weddingCoupleNames = null,
        List<DateTime>? weddingDates = null,
        List<string>? weddingStatuses = null,
        List<decimal>? weddingBudgets = null,
        List<string>? weddingLocations = null,
        List<int>? messageIds = null,
        List<string>? messageSenders = null,
        List<string>? messageReceivers = null,
        List<string>? messageContents = null,
        List<DateTime>? messageTimestamps = null,
        List<bool>? messageIsRead = null,
        List<int>? logisticsTaskIds = null,
        List<string>? logisticsTaskTypes = null,
        List<string>? logisticsTaskDescriptions = null,
        List<DateTime>? logisticsTaskScheduledTimes = null,
        List<string>? logisticsTaskStatuses = null,
        List<string>? popularVenueNames = null,
        List<int>? popularVenueCounts = null,
        List<string>? budgetTrendMonths = null,
        List<decimal>? budgetTrendAverageBudgets = null,
        List<string>? vendorPerformanceVendorNames = null,
        List<double>? vendorPerformanceAverageRatings = null,
        List<int>? vendorPerformanceBookingCounts = null,
        List<Vendor>? vendors = null)
    {
        public int TaskCompletionPercentage { get; init; } = taskCompletionPercentage;
        public decimal TotalBudget { get; init; } = totalBudget;
        public decimal FundsAllocated { get; init; } = fundsAllocated;
        public decimal FundsSpent { get; init; } = fundsSpent;
        public List<int> UpcomingDeadlineIds { get; init; } = upcomingDeadlineIds ?? [];
        public List<string> UpcomingDeadlineTaskNames { get; init; } = upcomingDeadlineTaskNames ?? [];
        public List<DateTime> UpcomingDeadlineDueDates { get; init; } = upcomingDeadlineDueDates ?? [];
        public List<int> ChecklistIds { get; init; } = checklistIds ?? [];
        public List<string> ChecklistDescriptions { get; init; } = checklistDescriptions ?? [];
        public List<DateTime> ChecklistDeadlines { get; init; } = checklistDeadlines ?? [];
        public List<bool> ChecklistIsCompleted { get; init; } = checklistIsCompleted ?? [];
        public List<int> GuestIds { get; init; } = guestIds ?? [];
        public List<string> GuestNames { get; init; } = guestNames ?? [];
        public List<string> GuestEmails { get; init; } = guestEmails ?? [];
        public List<string> GuestPhones { get; init; } = guestPhones ?? [];
        public List<string> GuestRelationships { get; init; } = guestRelationships ?? [];
        public List<string> GuestRSVPStatuses { get; init; } = guestRSVPStatuses ?? [];
        public List<string> GuestMealPreferences { get; init; } = guestMealPreferences ?? [];
        public List<string> GuestSeatingAssignments { get; init; } = guestSeatingAssignments ?? [];
        public List<int> BudgetCategoryIds { get; init; } = budgetCategoryIds ?? [];
        public List<string> BudgetCategoryCategories { get; init; } = budgetCategoryCategories ?? [];
        public List<decimal> BudgetCategoryAllocatedAmounts { get; init; } = budgetCategoryAllocatedAmounts ?? [];
        public List<decimal> BudgetCategorySpentAmounts { get; init; } = budgetCategorySpentAmounts ?? [];
        public List<int> TimelineEventIds { get; init; } = timelineEventIds ?? [];
        public List<string> TimelineEventNames { get; init; } = timelineEventNames ?? [];
        public List<DateTime> TimelineEventStartTimes { get; init; } = timelineEventStartTimes ?? [];
        public List<DateTime> TimelineEventEndTimes { get; init; } = timelineEventEndTimes ?? [];
        public List<int> WeddingIds { get; init; } = weddingIds ?? [];
        public List<string> WeddingCoupleNames { get; init; } = weddingCoupleNames ?? [];
        public List<DateTime> WeddingDates { get; init; } = weddingDates ?? [];
        public List<string> WeddingStatuses { get; init; } = weddingStatuses ?? [];
        public List<decimal> WeddingBudgets { get; init; } = weddingBudgets ?? [];
        public List<string> WeddingLocations { get; init; } = weddingLocations ?? [];
        public List<int> MessageIds { get; init; } = messageIds ?? [];
        public List<string> MessageSenders { get; init; } = messageSenders ?? [];
        public List<string> MessageReceivers { get; init; } = messageReceivers ?? [];
        public List<string> MessageContents { get; init; } = messageContents ?? [];
        public List<DateTime> MessageTimestamps { get; init; } = messageTimestamps ?? [];
        public List<bool> MessageIsRead { get; init; } = messageIsRead ?? [];
        public List<int> LogisticsTaskIds { get; init; } = logisticsTaskIds ?? [];
        public List<string> LogisticsTaskTypes { get; init; } = logisticsTaskTypes ?? [];
        public List<string> LogisticsTaskDescriptions { get; init; } = logisticsTaskDescriptions ?? [];
        public List<DateTime> LogisticsTaskScheduledTimes { get; init; } = logisticsTaskScheduledTimes ?? [];
        public List<string> LogisticsTaskStatuses { get; init; } = logisticsTaskStatuses ?? [];
        public List<string> PopularVenueNames { get; init; } = popularVenueNames ?? [];
        public List<int> PopularVenueCounts { get; init; } = popularVenueCounts ?? [];
        public List<string> BudgetTrendMonths { get; init; } = budgetTrendMonths ?? [];
        public List<decimal> BudgetTrendAverageBudgets { get; init; } = budgetTrendAverageBudgets ?? [];
        public List<string> VendorPerformanceVendorNames { get; init; } = vendorPerformanceVendorNames ?? [];
        public List<double> VendorPerformanceAverageRatings { get; init; } = vendorPerformanceAverageRatings ?? [];
        public List<int> VendorPerformanceBookingCounts { get; init; } = vendorPerformanceBookingCounts ?? [];
        public List<Vendor> Vendors { get; init; } = vendors ?? [];
    }

    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Availability { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }

    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public double Rating { get; set; }
    }

    public class Deadline
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}