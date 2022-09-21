using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkManager31.Data.Migrations
{
    public partial class DatabaseDeletecascadeconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientGroupElement_Client_ClientId",
                schema: "Identity",
                table: "ClientGroupElement");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                schema: "Identity",
                table: "ClientGroupElement",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientGroupId",
                schema: "Identity",
                table: "ClientGroupElement",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroupElement_Client_ClientId",
                schema: "Identity",
                table: "ClientGroupElement",
                column: "ClientId",
                principalSchema: "Identity",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientGroupElement_Client_ClientId",
                schema: "Identity",
                table: "ClientGroupElement");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                schema: "Identity",
                table: "ClientGroupElement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClientGroupId",
                schema: "Identity",
                table: "ClientGroupElement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroupElement_Client_ClientId",
                schema: "Identity",
                table: "ClientGroupElement",
                column: "ClientId",
                principalSchema: "Identity",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
