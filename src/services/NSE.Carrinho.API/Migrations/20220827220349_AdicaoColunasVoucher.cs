using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSE.Carrinho.API.Migrations
{
    public partial class AdicaoColunasVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Desconto",
                table: "CarrinhoClientes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Percentual",
                table: "CarrinhoClientes",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDesconto",
                table: "CarrinhoClientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDesconto",
                table: "CarrinhoClientes",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherCodigo",
                table: "CarrinhoClientes",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "VoucherUtilizado",
                table: "CarrinhoClientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "Percentual",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "TipoDesconto",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "ValorDesconto",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "VoucherCodigo",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "VoucherUtilizado",
                table: "CarrinhoClientes");
        }
    }
}
