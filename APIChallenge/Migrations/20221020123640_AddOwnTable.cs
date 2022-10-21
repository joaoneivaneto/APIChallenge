using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIChallenge.Migrations
{
    public partial class AddOwnTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Projetoid_projeto",
                table: "Empregados",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Projetos",
                keyColumn: "id_projeto",
                keyValue: 1,
                columns: new[] { "data_de_criação", "data_temino" },
                values: new object[] { new DateTime(2022, 10, 20, 9, 36, 38, 338, DateTimeKind.Local).AddTicks(8227), new DateTime(2022, 10, 20, 9, 36, 38, 339, DateTimeKind.Local).AddTicks(7720) });

            migrationBuilder.CreateIndex(
                name: "IX_Empregados_Projetoid_projeto",
                table: "Empregados",
                column: "Projetoid_projeto");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregados_Projetos_Projetoid_projeto",
                table: "Empregados",
                column: "Projetoid_projeto",
                principalTable: "Projetos",
                principalColumn: "id_projeto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empregados_Projetos_Projetoid_projeto",
                table: "Empregados");

            migrationBuilder.DropIndex(
                name: "IX_Empregados_Projetoid_projeto",
                table: "Empregados");

            migrationBuilder.DropColumn(
                name: "Projetoid_projeto",
                table: "Empregados");

            migrationBuilder.UpdateData(
                table: "Projetos",
                keyColumn: "id_projeto",
                keyValue: 1,
                columns: new[] { "data_de_criação", "data_temino" },
                values: new object[] { new DateTime(2022, 10, 20, 9, 22, 10, 764, DateTimeKind.Local).AddTicks(9674), new DateTime(2022, 10, 20, 9, 22, 10, 766, DateTimeKind.Local).AddTicks(945) });

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Company",
                table: "Clients");
        }
    }  
}
