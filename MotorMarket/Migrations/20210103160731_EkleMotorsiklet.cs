using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorMarket.Migrations
{
    public partial class EkleMotorsiklet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorsiklets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainID = table.Column<int>(nullable: false),
                    ModelID = table.Column<int>(nullable: false),
                    Yil = table.Column<int>(nullable: false),
                    KM = table.Column<int>(nullable: false),
                    Ozellikler = table.Column<string>(nullable: true),
                    SaticiName = table.Column<string>(nullable: false),
                    SaticiEmail = table.Column<string>(nullable: true),
                    SaticiTelefon = table.Column<string>(nullable: false),
                    Fiyat = table.Column<int>(nullable: false),
                    Para = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorsiklets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorsiklets_Mains_MainID",
                        column: x => x.MainID,
                        principalTable: "Mains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Motorsiklets_Models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorsiklets_MainID",
                table: "Motorsiklets",
                column: "MainID");

            migrationBuilder.CreateIndex(
                name: "IX_Motorsiklets_ModelID",
                table: "Motorsiklets",
                column: "ModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorsiklets");
        }
    }
}
