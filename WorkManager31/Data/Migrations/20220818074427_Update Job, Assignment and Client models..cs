using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkManager31.Data.Migrations
{
    public partial class UpdateJobAssignmentandClientmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignment",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    AssignmentId = table.Column<int>(nullable: false),
                    Del = table.Column<bool>(nullable: false),
                    Done = table.Column<bool>(nullable: false),
                    DoneByUserId = table.Column<int>(nullable: false),
                    DoneDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalSchema: "Identity",
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Identity",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_AssignmentId",
                schema: "Identity",
                table: "Job",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ClientId",
                schema: "Identity",
                table: "Job",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Assignment",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "Identity");
        }
    }
}
