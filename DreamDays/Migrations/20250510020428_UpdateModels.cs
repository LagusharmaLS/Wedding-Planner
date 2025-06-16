using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDays.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2025, 5, 17, 7, 34, 27, 645, DateTimeKind.Local).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2025, 5, 24, 7, 34, 27, 646, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2025, 5, 20, 7, 34, 27, 646, DateTimeKind.Local).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Couples",
                keyColumn: "Id",
                keyValue: 1,
                column: "WeddingDate",
                value: new DateTime(2025, 11, 10, 7, 34, 27, 646, DateTimeKind.Local).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "Couples",
                keyColumn: "Id",
                keyValue: 2,
                column: "WeddingDate",
                value: new DateTime(2026, 1, 10, 7, 34, 27, 646, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "LogisticsTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledTime",
                value: new DateTime(2025, 5, 15, 7, 34, 27, 646, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "LogisticsTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScheduledTime",
                value: new DateTime(2025, 5, 13, 7, 34, 27, 646, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 5, 10, 5, 34, 27, 646, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 5, 10, 6, 34, 27, 646, DateTimeKind.Local).AddTicks(7304));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2025, 5, 17, 7, 16, 18, 622, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2025, 5, 24, 7, 16, 18, 623, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2025, 5, 20, 7, 16, 18, 623, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Couples",
                keyColumn: "Id",
                keyValue: 1,
                column: "WeddingDate",
                value: new DateTime(2025, 11, 10, 7, 16, 18, 624, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Couples",
                keyColumn: "Id",
                keyValue: 2,
                column: "WeddingDate",
                value: new DateTime(2026, 1, 10, 7, 16, 18, 624, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "LogisticsTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledTime",
                value: new DateTime(2025, 5, 15, 7, 16, 18, 623, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "LogisticsTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScheduledTime",
                value: new DateTime(2025, 5, 13, 7, 16, 18, 624, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 5, 10, 5, 16, 18, 623, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 5, 10, 6, 16, 18, 623, DateTimeKind.Local).AddTicks(9144));
        }
    }
}
