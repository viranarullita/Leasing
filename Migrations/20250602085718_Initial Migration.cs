using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IRRDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bulan = table.Column<int>(type: "int", nullable: false),
                    NilaiPV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IRRDetail", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeasingInput",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Harga = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DP = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CicilanPerBulan = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LamaBulan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasingInput", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeasingResult",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TotalAngsuran = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SisaPembayaran = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProfitLeasing = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PresentasiKeuntungan = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NPV10 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NPV20 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NPV30 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NPV40 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NPV50 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IRR = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasingResult", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NPVChartPoint",
                columns: table => new
                {
                    Interest = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NPV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PVDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bulan = table.Column<int>(type: "int", nullable: false),
                    NilaiPV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVDetail", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IRRDetail");

            migrationBuilder.DropTable(
                name: "LeasingInput");

            migrationBuilder.DropTable(
                name: "LeasingResult");

            migrationBuilder.DropTable(
                name: "NPVChartPoint");

            migrationBuilder.DropTable(
                name: "PVDetail");
        }
    }
}
