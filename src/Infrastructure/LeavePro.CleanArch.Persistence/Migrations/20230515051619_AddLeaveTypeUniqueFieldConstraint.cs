using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeavePro.CleanArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveTypeUniqueFieldConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 15, 9, 46, 18, 986, DateTimeKind.Local).AddTicks(4300), new DateTime(2023, 5, 15, 9, 46, 18, 986, DateTimeKind.Local).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 15, 9, 46, 18, 986, DateTimeKind.Local).AddTicks(4377), new DateTime(2023, 5, 15, 9, 46, 18, 986, DateTimeKind.Local).AddTicks(4381) });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_Name",
                table: "LeaveTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LeaveTypes_Name",
                table: "LeaveTypes");

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 12, 12, 23, 36, 60, DateTimeKind.Local).AddTicks(5331), new DateTime(2023, 5, 12, 12, 23, 36, 60, DateTimeKind.Local).AddTicks(5499) });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 12, 12, 23, 36, 60, DateTimeKind.Local).AddTicks(5509), new DateTime(2023, 5, 12, 12, 23, 36, 60, DateTimeKind.Local).AddTicks(5512) });
        }
    }
}
