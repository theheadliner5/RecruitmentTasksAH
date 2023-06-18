using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentTasksAH.FirstTask.Migrations
{
    /// <inheritdoc />
    public partial class AccountNumbersEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountNumber_Entrepreneurs_EntrepreneurId",
                table: "AccountNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountNumber",
                table: "AccountNumber");

            migrationBuilder.RenameTable(
                name: "AccountNumber",
                newName: "AccountNumbers");

            migrationBuilder.RenameIndex(
                name: "IX_AccountNumber_EntrepreneurId",
                table: "AccountNumbers",
                newName: "IX_AccountNumbers_EntrepreneurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountNumbers",
                table: "AccountNumbers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountNumbers_Entrepreneurs_EntrepreneurId",
                table: "AccountNumbers",
                column: "EntrepreneurId",
                principalTable: "Entrepreneurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountNumbers_Entrepreneurs_EntrepreneurId",
                table: "AccountNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountNumbers",
                table: "AccountNumbers");

            migrationBuilder.RenameTable(
                name: "AccountNumbers",
                newName: "AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_AccountNumbers_EntrepreneurId",
                table: "AccountNumber",
                newName: "IX_AccountNumber_EntrepreneurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountNumber",
                table: "AccountNumber",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountNumber_Entrepreneurs_EntrepreneurId",
                table: "AccountNumber",
                column: "EntrepreneurId",
                principalTable: "Entrepreneurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
