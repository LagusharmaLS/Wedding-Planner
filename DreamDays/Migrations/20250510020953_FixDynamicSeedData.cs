using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDays.Migrations
{
    /// <inheritdoc />
    public partial class FixDynamicSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ChecklistItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Couples",
                keyColumn: "Id",
                keyValue: 1,
                column: "WeddingDate",
                value: new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Couples",
                keyColumn: "Id",
                keyValue: 2,
                column: "WeddingDate",
                value: new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "LogisticsTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledTime",
                value: new DateTime(2024, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "LogisticsTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScheduledTime",
                value: new DateTime(2024, 5, 13, 14, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 5, 10, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 5, 10, 13, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
