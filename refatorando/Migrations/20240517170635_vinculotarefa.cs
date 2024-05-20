using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refatorando.Migrations
{
    /// <inheritdoc />
    public partial class vinculotarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "tbendereco",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "tbendereco",
                newName: "Rua");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "tbendereco",
                newName: "Estado");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "tbendereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "tbendereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbendereco_AlunoId",
                table: "tbendereco",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbendereco_tbalunos_AlunoId",
                table: "tbendereco",
                column: "AlunoId",
                principalTable: "tbalunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "tbendereco");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "tbendereco",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "Rua",
                table: "tbendereco",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "tbendereco",
                newName: "Complemento");
        }
    }
}
