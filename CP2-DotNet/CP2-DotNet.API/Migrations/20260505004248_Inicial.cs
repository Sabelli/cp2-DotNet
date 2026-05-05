using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2_DotNet.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    f_titulo = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    f_anolancamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    f_genero = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    f_duracao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    a_autor = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    a_nota = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    a_comentario = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    a_dataavaliacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    f_id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_tb_filme_f_id",
                        column: x => x.f_id,
                        principalTable: "tb_filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_f_id",
                table: "tb_avaliacao",
                column: "f_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_avaliacao");

            migrationBuilder.DropTable(
                name: "tb_filme");
        }
    }
}
