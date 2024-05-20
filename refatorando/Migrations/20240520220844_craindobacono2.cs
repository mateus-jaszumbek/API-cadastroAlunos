using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refatorando.Migrations
{
    /// <inheritdoc />
    public partial class craindobacono2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbendereco_tbalunos_AlunoId",
                table: "tbendereco");

            migrationBuilder.DropIndex(
                name: "IX_tbendereco_AlunoId",
                table: "tbendereco");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "tbendereco");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "tbalunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbalunos_EnderecoId",
                table: "tbalunos",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbalunos_tbendereco_EnderecoId",
                table: "tbalunos",
                column: "EnderecoId",
                principalTable: "tbendereco",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbalunos_tbendereco_EnderecoId",
                table: "tbalunos");

            migrationBuilder.DropIndex(
                name: "IX_tbalunos_EnderecoId",
                table: "tbalunos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "tbalunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "tbendereco",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbendereco_AlunoId",
                table: "tbendereco",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbendereco_tbalunos_AlunoId",
                table: "tbendereco",
                column: "AlunoId",
                principalTable: "tbalunos",
                principalColumn: "Id");
        }
    }
}
