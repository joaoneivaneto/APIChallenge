using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIChallenge.Migrations
{
    public partial class AddProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    id_projeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_de_criação = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_temino = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    gerente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.id_projeto);
                    table.ForeignKey(
                        name: "FK_Projetos_Empregados_gerente",
                        column: x => x.gerente,
                        principalTable: "Empregados",
                        principalColumn: "id_empregado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "id_projeto", "data_de_criação", "data_temino", "gerente", "nome" },
                values: new object[] { 1, new DateTime(2022, 10, 19, 22, 4, 9, 777, DateTimeKind.Local).AddTicks(5715), new DateTime(2022, 10, 19, 22, 4, 9, 778, DateTimeKind.Local).AddTicks(5538), 1, "Leonardo" });

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_gerente",
                table: "Projetos",
                column: "gerente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projetos");
           
        }
    }
}
