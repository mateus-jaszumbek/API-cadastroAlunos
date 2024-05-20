using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refatorando.Migrations
{
    /// <inheritdoc />
    public partial class criarBancoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "tbalunos",
                newName: "TipoEnderec");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoEnderec",
                table: "tbalunos",
                newName: "Tipo");
        }
    }
}
