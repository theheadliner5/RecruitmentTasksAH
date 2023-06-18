using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentTasksAH.FirstTask.Migrations
{
    /// <inheritdoc />
    public partial class EntrepreneurModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumbers",
                table: "Entrepreneurs");

            migrationBuilder.CreateTable(
                name: "AccountNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepreneurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountNumber_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountNumber_EntrepreneurId",
                table: "AccountNumber",
                column: "EntrepreneurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountNumber");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumbers",
                table: "Entrepreneurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
