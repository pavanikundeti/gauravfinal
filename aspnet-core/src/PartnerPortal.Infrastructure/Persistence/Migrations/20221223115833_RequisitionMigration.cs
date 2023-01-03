using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartnerPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RequisitionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "TodoLists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "TodoLists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "RateCards",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "RateCards",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "ProjectManagers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "ProjectManagers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequisitionID",
                table: "ProjectManagers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedBy",
                table: "Partners",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Partners",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequisitionID",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequisitionID",
                table: "Currencies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequisitionID",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "requisitions",
                columns: table => new
                {
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PotentialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complexity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCountreyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesPersonUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectManagerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedBudget = table.Column<double>(type: "float", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisitions", x => x.RequisitionID);
                    table.ForeignKey(
                        name: "FK_requisitions_Countries_ClientCountreyID",
                        column: x => x.ClientCountreyID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requisitions_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requisitions_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requisitions_ProjectManagers_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionFiles",
                columns: table => new
                {
                    RequisitionFileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionFiles", x => x.RequisitionFileID);
                    table.ForeignKey(
                        name: "FK_RequisitionFiles_requisitions_RequisitionID",
                        column: x => x.RequisitionID,
                        principalTable: "requisitions",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionJDs",
                columns: table => new
                {
                    RequisitionJDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DurationUnits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftTimings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfResources = table.Column<int>(type: "int", nullable: false),
                    OpenPositions = table.Column<int>(type: "int", nullable: false),
                    KeyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinExperience = table.Column<int>(type: "int", nullable: false),
                    MaxExperience = table.Column<int>(type: "int", nullable: false),
                    JDFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionJDs", x => x.RequisitionJDID);
                    table.ForeignKey(
                        name: "FK_RequisitionJDs_requisitions_RequisitionID",
                        column: x => x.RequisitionID,
                        principalTable: "requisitions",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionPartners",
                columns: table => new
                {
                    RequsitionPartnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionPartners", x => x.RequsitionPartnerID);
                    table.ForeignKey(
                        name: "FK_RequisitionPartners_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitionPartners_requisitions_RequestionID",
                        column: x => x.RequestionID,
                        principalTable: "requisitions",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionSkills",
                columns: table => new
                {
                    RequisitionSkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequisitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mandatory = table.Column<byte>(type: "tinyint", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionSkills", x => x.RequisitionSkillID);
                    table.ForeignKey(
                        name: "FK_RequisitionSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitionSkills_requisitions_RequisitionID",
                        column: x => x.RequisitionID,
                        principalTable: "requisitions",
                        principalColumn: "RequisitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagers_RequisitionID",
                table: "ProjectManagers",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_RequisitionID",
                table: "Departments",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_RequisitionID",
                table: "Currencies",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RequisitionID",
                table: "Countries",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionFiles_RequisitionID",
                table: "RequisitionFiles",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionJDs_RequisitionID",
                table: "RequisitionJDs",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionPartners_PartnerId",
                table: "RequisitionPartners",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionPartners_RequestionID",
                table: "RequisitionPartners",
                column: "RequestionID");

            migrationBuilder.CreateIndex(
                name: "IX_requisitions_ClientCountreyID",
                table: "requisitions",
                column: "ClientCountreyID");

            migrationBuilder.CreateIndex(
                name: "IX_requisitions_CurrencyID",
                table: "requisitions",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_requisitions_DepartmentID",
                table: "requisitions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_requisitions_ProjectManagerID",
                table: "requisitions",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionSkills_RequisitionID",
                table: "RequisitionSkills",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionSkills_SkillID",
                table: "RequisitionSkills",
                column: "SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_requisitions_RequisitionID",
                table: "Countries",
                column: "RequisitionID",
                principalTable: "requisitions",
                principalColumn: "RequisitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_requisitions_RequisitionID",
                table: "Currencies",
                column: "RequisitionID",
                principalTable: "requisitions",
                principalColumn: "RequisitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_requisitions_RequisitionID",
                table: "Departments",
                column: "RequisitionID",
                principalTable: "requisitions",
                principalColumn: "RequisitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagers_requisitions_RequisitionID",
                table: "ProjectManagers",
                column: "RequisitionID",
                principalTable: "requisitions",
                principalColumn: "RequisitionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_requisitions_RequisitionID",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_requisitions_RequisitionID",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_requisitions_RequisitionID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagers_requisitions_RequisitionID",
                table: "ProjectManagers");

            migrationBuilder.DropTable(
                name: "RequisitionFiles");

            migrationBuilder.DropTable(
                name: "RequisitionJDs");

            migrationBuilder.DropTable(
                name: "RequisitionPartners");

            migrationBuilder.DropTable(
                name: "RequisitionSkills");

            migrationBuilder.DropTable(
                name: "requisitions");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagers_RequisitionID",
                table: "ProjectManagers");

            migrationBuilder.DropIndex(
                name: "IX_Departments_RequisitionID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_RequisitionID",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_RequisitionID",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RequisitionID",
                table: "ProjectManagers");

            migrationBuilder.DropColumn(
                name: "RequisitionID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "RequisitionID",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "RequisitionID",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "RateCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "RateCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "ProjectManagers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ProjectManagers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
