using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkManager31.Data.Migrations
{
    public partial class AddClientGroupsmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientGroup",
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
                    table.PrimaryKey("PK_ClientGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientGroupElement",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ClientGroupId = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGroupElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientGroupElement_ClientGroup_ClientGroupId",
                        column: x => x.ClientGroupId,
                        principalSchema: "Identity",
                        principalTable: "ClientGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientGroupElement_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Identity",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupElement_ClientGroupId",
                schema: "Identity",
                table: "ClientGroupElement",
                column: "ClientGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupElement_ClientId",
                schema: "Identity",
                table: "ClientGroupElement",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientGroupElement",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ClientGroup",
                schema: "Identity");
        }
    }
}
