using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamDays.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChecklistItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Couples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partner1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partner2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogisticsTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticsTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMFAEnabled = table.Column<bool>(type: "bit", nullable: false),
                    WeddingEventId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoupleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChecklistItems",
                columns: new[] { "Id", "Deadline", "Description", "IsCompleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 17, 7, 16, 18, 622, DateTimeKind.Local).AddTicks(6614), "Book Venue", false },
                    { 2, new DateTime(2025, 5, 24, 7, 16, 18, 623, DateTimeKind.Local).AddTicks(5577), "Send Invitations", true },
                    { 3, new DateTime(2025, 5, 20, 7, 16, 18, 623, DateTimeKind.Local).AddTicks(5588), "Choose Caterer", false }
                });

            migrationBuilder.InsertData(
                table: "Couples",
                columns: new[] { "Id", "Email", "Partner1Name", "Partner2Name", "WeddingDate" },
                values: new object[,]
                {
                    { 1, "john.jane@example.com", "John", "Jane", new DateTime(2025, 11, 10, 7, 16, 18, 624, DateTimeKind.Local).AddTicks(1101) },
                    { 2, "alice.bob@example.com", "Alice", "Bob", new DateTime(2026, 1, 10, 7, 16, 18, 624, DateTimeKind.Local).AddTicks(1279) }
                });

            migrationBuilder.InsertData(
                table: "LogisticsTasks",
                columns: new[] { "Id", "Description", "ScheduledTime", "Status", "TaskType" },
                values: new object[,]
                {
                    { 1, "Arrange transport for guests", new DateTime(2025, 5, 15, 7, 16, 18, 623, DateTimeKind.Local).AddTicks(9947), "Pending", "Transportation" },
                    { 2, "Confirm menu with vendor", new DateTime(2025, 5, 13, 7, 16, 18, 624, DateTimeKind.Local).AddTicks(209), "In Progress", "Catering" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "IsRead", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Can we discuss the venue options?", false, "Planner", "John & Jane", new DateTime(2025, 5, 10, 5, 16, 18, 623, DateTimeKind.Local).AddTicks(8859) },
                    { 2, "Please confirm the catering menu.", true, "Alice & Bob", "Planner", new DateTime(2025, 5, 10, 6, 16, 18, 623, DateTimeKind.Local).AddTicks(9144) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsMFAEnabled", "Name", "Password", "Role", "WeddingEventId" },
                values: new object[,]
                {
                    { 1, "admin@dreamdays.com", false, null, "Admin123!", "Admin", null },
                    { 2, "planner@dreamdays.com", false, null, "Planner123!", "Planner", null }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Availability", "Category", "ContactInfo", "Description", "IsFavorite", "Location", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "Available", "Venue", "contact@elegantvenues.com", "Beautiful venue for weddings with elegant decor", false, "New York, NY", "Elegant Venues", 15000m, 4.5 },
                    { 2, "Booked", "Catering", "contact@tastycatering.com", "Delicious wedding catering with customizable menus", true, "Los Angeles, CA", "Tasty Catering", 5000m, 4.0 },
                    { 3, "Available", "Florist", "contact@bloomflorist.com", "Stunning floral arrangements for weddings", false, "Chicago, IL", "Bloom Florist", 2000m, 4.7999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Weddings",
                columns: new[] { "Id", "Budget", "CoupleName", "Date", "Location", "Status" },
                values: new object[,]
                {
                    { 1, 50000m, "John & Jane", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombo 07", "Planning" },
                    { 2, 60000m, "Alice & Bob", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Galle Face", "Planning" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_VendorId",
                table: "Reviews",
                column: "VendorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistItems");

            migrationBuilder.DropTable(
                name: "Couples");

            migrationBuilder.DropTable(
                name: "LogisticsTasks");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
