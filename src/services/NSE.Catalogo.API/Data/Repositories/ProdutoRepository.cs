using NSE.Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using Dapper;

#nullable disable
namespace NSE.Catalogo.API.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;

        public ProdutoRepository(CatalogoContext context) => _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task<PagedResult<Produto>> ObterTodos(int pageSize, int pageIndex, string? query = null)
        {
            // Será utilizado o Dapper, mas no EF Core é bem facil usando Skip (OFFSET) e Take (FETCH)
            // Será feito dois selects numa mesma consulta usando o recurso QueryMultiple do dapper

            var sqls = @$"
                SELECT * FROM Produtos 
                WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
                ORDER BY [Nome] 
                OFFSET {pageSize * (pageIndex - 1)} ROWS 
                FETCH NEXT {pageSize} ROWS ONLY

                SELECT COUNT(Id) FROM Produtos 
                WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')
            ";

            SqlMapper.GridReader multipleQueries = await _context.Database.GetDbConnection()
                .QueryMultipleAsync(sqls, new { Nome = query });

            var produtos = await multipleQueries.ReadAsync<Produto>();
            var totalItens = await multipleQueries.ReadFirstAsync<int>();

            return new PagedResult<Produto>()
            {
                List = produtos,
                TotalResults = totalItens,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        public async Task<Produto> ObterPorId(Guid id) => await _context.Produtos.FindAsync(id);

        public async Task<List<Produto>> ObterProdutosPorId(string ids)
        {
            var idsGuid = ids.Split(',')
                .Select(id => (Ok: Guid.TryParse(id, out var x), Value: x));

            if (!idsGuid.All(nid => nid.Ok)) return new List<Produto>();

            var idsValue = idsGuid.Select(id => id.Value);

            return await _context.Produtos.AsNoTracking()
                .Where(p => idsValue.Contains(p.Id) && p.Ativo).ToListAsync();
        }

        public void Adicionar(Produto produto) => _context.Produtos.Add(produto);

        public void Atualizar(Produto produto) => _context.Produtos.Update(produto);

        public void Dispose() => _context?.Dispose();
    }
}