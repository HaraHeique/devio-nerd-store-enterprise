using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
namespace NSE.Carrinho.API.Migrations
{
    public partial class DeleteCascadeCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoClienteId",
                table: "CarrinhoItens");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoClienteId",
                table: "CarrinhoItens",
                column: "CarrinhoClienteId",
                principalTable: "CarrinhoClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoClienteId",
                table: "CarrinhoItens");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoClienteId",
                table: "CarrinhoItens",
                column: "CarrinhoClienteId",
                principalTable: "CarrinhoClientes",
                principalColumn: "Id");
        }
    }
}
