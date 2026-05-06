using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2_DotNet.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDiretorToFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_avaliacao_tb_filme_f_id",
                table: "tb_avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_tb_avaliacao_f_id",
                table: "tb_avaliacao");

            migrationBuilder.AddColumn<string>(
                name: "f_diretor",
                table: "tb_filme",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "f_diretor",
                table: "tb_filme");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_f_id",
                table: "tb_avaliacao",
                column: "f_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_avaliacao_tb_filme_f_id",
                table: "tb_avaliacao",
                column: "f_id",
                principalTable: "tb_filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
