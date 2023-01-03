using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartnerPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6977285d-cf0c-4bba-b4dd-221fd1aa611a", "4", "Sales", "SALES" },
                    { "8ffe2535-e434-4238-b37a-1b19bf35fb72", "2", "ProjectManager", "PROJECTMANAGER" },
                    { "e17461c8-83b6-4559-90c5-b1570bd1b2d7", "3", "Partner", "PARTNER" },
                    { "e39cdf2d-850b-4d64-8c1a-08d2c0427c2b", "5", "Ops", "OPS" },
                    { "eee8219a-3ee3-42f1-a491-435e3dd512e1", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6977285d-cf0c-4bba-b4dd-221fd1aa611a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ffe2535-e434-4238-b37a-1b19bf35fb72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e17461c8-83b6-4559-90c5-b1570bd1b2d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39cdf2d-850b-4d64-8c1a-08d2c0427c2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eee8219a-3ee3-42f1-a491-435e3dd512e1");
        }
    }
}
