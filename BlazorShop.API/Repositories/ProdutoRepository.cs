using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetItens()
        {
            var produtos = await _context.Produtos
                                         .Include(p => p.Categoria)
                                         .ToListAsync();

            return produtos;
        }

        public async Task<Produto> GetItem(int id)
        {
            var produto = await _context.Produtos
                                             .Include(p => p.Categoria)
                                             .SingleOrDefaultAsync(p => p.Id == id);

            return produto;

        }

        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int CategoriaId)
        {
            var produto = await _context.Produtos
                                 .Include(p => p.Categoria)
                                 .Where(p => p.CategoriaId == CategoriaId)
                                 .ToListAsync();

            return produto;
        }
    }
}
