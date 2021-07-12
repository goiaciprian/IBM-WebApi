using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IBM_WebApi.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaciVideo",
                columns: table => new
                {
                    ID_Gpu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Sters = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaciVideo", x => x.ID_Gpu);
                });

            migrationBuilder.CreateTable(
                name: "Procesoare",
                columns: table => new
                {
                    ID_Cpu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chipset = table.Column<bool>(type: "bit", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Sters = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesoare", x => x.ID_Cpu);
                });

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    ID_Ram = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Memorie = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Sters = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.ID_Ram);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Sters = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Pcs",
                columns: table => new
                {
                    ID_Pc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Cpu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Gpu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Ram = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Sters = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pcs", x => x.ID_Pc);
                    table.ForeignKey(
                        name: "FK_Pcs_PlaciVideo_ID_Gpu",
                        column: x => x.ID_Gpu,
                        principalTable: "PlaciVideo",
                        principalColumn: "ID_Gpu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pcs_Procesoare_ID_Cpu",
                        column: x => x.ID_Cpu,
                        principalTable: "Procesoare",
                        principalColumn: "ID_Cpu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pcs_Ram_ID_Ram",
                        column: x => x.ID_Ram,
                        principalTable: "Ram",
                        principalColumn: "ID_Ram",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_ID_Cpu",
                table: "Pcs",
                column: "ID_Cpu");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_ID_Gpu",
                table: "Pcs",
                column: "ID_Gpu");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_ID_Ram",
                table: "Pcs",
                column: "ID_Ram");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pcs");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PlaciVideo");

            migrationBuilder.DropTable(
                name: "Procesoare");

            migrationBuilder.DropTable(
                name: "Ram");
        }
    }
}
