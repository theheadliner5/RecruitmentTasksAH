using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentTasksAH.FirstTask.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrepreneurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestorationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasVirtualAccounts = table.Column<bool>(type: "bit", nullable: false),
                    StatusVat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Krs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestorationBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDenialBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemovalDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationLegalDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemovalBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDenialDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrepreneurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepreneurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representatives_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_EntrepreneurId",
                table: "Representatives",
                column: "EntrepreneurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "Entrepreneurs");
        }
    }
}
