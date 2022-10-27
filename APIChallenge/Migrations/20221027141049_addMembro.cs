using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIChallenge.Migrations
{
    public partial class addMembro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "membros",
                columns: table => new
                {
                    id_empregado = table.Column<int>(type: "int", nullable: false),
                    id_projeto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membros", x => new { x.id_empregado, x.id_projeto });
                    table.ForeignKey(
                        name: "FK_membros_Empregados_id_empregado",
                        column: x => x.id_empregado,
                        principalTable: "Empregados",
                        principalColumn: "id_empregado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_membros_Projetos_id_projeto",
                        column: x => x.id_projeto,
                        principalTable: "Projetos",
                        principalColumn: "id_projeto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Projetos",
                keyColumn: "id_projeto",
                keyValue: 1,
                columns: new[] { "data_de_criação", "data_temino" },
                values: new object[] { new DateTime(2022, 10, 27, 11, 10, 49, 126, DateTimeKind.Local).AddTicks(9125), new DateTime(2022, 10, 27, 11, 10, 49, 127, DateTimeKind.Local).AddTicks(7856) });

            migrationBuilder.CreateIndex(
                name: "IX_membros_id_projeto",
                table: "membros",
                column: "id_projeto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "membros");

            migrationBuilder.UpdateData(
                table: "Projetos",
                keyColumn: "id_projeto",
                keyValue: 1,
                columns: new[] { "data_de_criação", "data_temino" },
                values: new object[] { new DateTime(2022, 10, 20, 9, 22, 10, 764, DateTimeKind.Local).AddTicks(9674), new DateTime(2022, 10, 20, 9, 22, 10, 766, DateTimeKind.Local).AddTicks(945) });
        }
    }
}
