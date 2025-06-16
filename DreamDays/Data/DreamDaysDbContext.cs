using Microsoft.EntityFrameworkCore;
using DreamDays.Models;
using System;
using System.Collections.Generic;

namespace DreamDays.Data
{
    public class DreamDaysDbContext : DbContext
    {
        public DreamDaysDbContext(DbContextOptions<DreamDaysDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WeddingEntity> Weddings { get; set; }
        public DbSet<ChecklistItemEntity> ChecklistItems { get; set; }
        public DbSet<VendorEntity> Vendors { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<LogisticsTaskEntity> LogisticsTasks { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<CoupleEntity> Couples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendorEntity>()
                .HasMany(v => v.Reviews)
                .WithOne()
                .HasForeignKey(r => r.VendorId);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin@dreamdays.com", Password = "Admin123!", Role = "Admin" },
                new User { Id = 2, Email = "planner@dreamdays.com", Password = "Planner123!", Role = "Planner" }
            );

            modelBuilder.Entity<WeddingEntity>().HasData(
                new WeddingEntity { Id = 1, CoupleName = "John & Jane", Date = new DateTime(2024, 10, 1), Location = "Colombo 07", Budget = 50000, Status = "Planning" },
                new WeddingEntity { Id = 2, CoupleName = "Alice & Bob", Date = new DateTime(2024, 10, 9), Location = "Galle Face", Budget = 60000, Status = "Planning" }
            );

            modelBuilder.Entity<ChecklistItemEntity>().HasData(
                new ChecklistItemEntity { Id = 1, Description = "Book Venue", Deadline = new DateTime(2024, 5, 17), IsCompleted = false },  // Static date
                new ChecklistItemEntity { Id = 2, Description = "Send Invitations", Deadline = new DateTime(2024, 5, 24), IsCompleted = true },  // Static date
                new ChecklistItemEntity { Id = 3, Description = "Choose Caterer", Deadline = new DateTime(2024, 5, 20), IsCompleted = false }   // Static date
            );

            modelBuilder.Entity<VendorEntity>().HasData(
                new VendorEntity
                {
                    Id = 1,
                    Name = "Elegant Venues",
                    Category = "Venue",
                    Description = "Beautiful venue for weddings with elegant decor",
                    Price = 15000,
                    Rating = 4.5,
                    ContactInfo = "contact@elegantvenues.com",
                    Location = "New York, NY",
                    Availability = "Available",
                    IsFavorite = false
                },
                new VendorEntity
                {
                    Id = 2,
                    Name = "Tasty Catering",
                    Category = "Catering",
                    Description = "Delicious wedding catering with customizable menus",
                    Price = 5000,
                    Rating = 4.0,
                    ContactInfo = "contact@tastycatering.com",
                    Location = "Los Angeles, CA",
                    Availability = "Booked",
                    IsFavorite = true
                },
                new VendorEntity
                {
                    Id = 3,
                    Name = "Bloom Florist",
                    Category = "Florist",
                    Description = "Stunning floral arrangements for weddings",
                    Price = 2000,
                    Rating = 4.8,
                    ContactInfo = "contact@bloomflorist.com",
                    Location = "Chicago, IL",
                    Availability = "Available",
                    IsFavorite = false
                }
            );

            modelBuilder.Entity<MessageEntity>().HasData(
                new MessageEntity { Id = 1, Sender = "John & Jane", Receiver = "Planner", Content = "Can we discuss the venue options?", Timestamp = new DateTime(2024, 5, 10, 12, 0, 0), IsRead = false }, // Static timestamp
                new MessageEntity { Id = 2, Sender = "Planner", Receiver = "Alice & Bob", Content = "Please confirm the catering menu.", Timestamp = new DateTime(2024, 5, 10, 13, 0, 0), IsRead = true }  // Static timestamp
            );

            modelBuilder.Entity<LogisticsTaskEntity>().HasData(
                new LogisticsTaskEntity { Id = 1, TaskType = "Transportation", Description = "Arrange transport for guests", ScheduledTime = new DateTime(2024, 5, 15, 9, 0, 0), Status = "Pending" }, // Static timestamp
                new LogisticsTaskEntity { Id = 2, TaskType = "Catering", Description = "Confirm menu with vendor", ScheduledTime = new DateTime(2024, 5, 13, 14, 0, 0), Status = "In Progress" } // Static timestamp
            );

            modelBuilder.Entity<CoupleEntity>().HasData(
                new CoupleEntity { Id = 1, Partner1Name = "John", Partner2Name = "Jane", Email = "john.jane@example.com", WeddingDate = new DateTime(2024, 10, 1) }, // Static date
                new CoupleEntity { Id = 2, Partner1Name = "Alice", Partner2Name = "Bob", Email = "alice.bob@example.com", WeddingDate = new DateTime(2024, 10, 9) }  // Static date
            );

            // Define precision and scale for decimal properties
            modelBuilder.Entity<VendorEntity>()
                .Property(v => v.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<WeddingEntity>()
                .Property(w => w.Budget)
                .HasColumnType("decimal(18,2)");
        }

        public class WeddingEntity
        {
            public int Id { get; set; }
            public string CoupleName { get; set; } = string.Empty;
            public DateTime Date { get; set; }
            public string Status { get; set; } = string.Empty;
            public decimal Budget { get; set; }
            public string Location { get; set; } = string.Empty;
        }

        public class ChecklistItemEntity
        {
            public int Id { get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime Deadline { get; set; }
            public bool IsCompleted { get; set; }
        }

        public class VendorEntity
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public double Rating { get; set; }
            public string ContactInfo { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public string Availability { get; set; } = string.Empty;
            public bool IsFavorite { get; set; }
            public List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
        }

        public class ReviewEntity
        {
            public int Id { get; set; }
            public string Comment { get; set; } = string.Empty;
            public double Rating { get; set; }
            public int VendorId { get; set; }
        }

        public class MessageEntity
        {
            public int Id { get; set; }
            public string Sender { get; set; } = string.Empty;
            public string Receiver { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public DateTime Timestamp { get; set; }
            public bool IsRead { get; set; }
        }

        public class LogisticsTaskEntity
        {
            public int Id { get; set; }
            public string TaskType { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public DateTime ScheduledTime { get; set; }
            public string Status { get; set; } = string.Empty;
        }

        public class CoupleEntity
        {
            public int Id { get; set; }
            public string Partner1Name { get; set; } = string.Empty;
            public string Partner2Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public DateTime WeddingDate { get; set; }
        }
    }
}