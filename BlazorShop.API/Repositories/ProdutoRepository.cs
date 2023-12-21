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

        public async Task<Produto> GetItemById(int id)
        {
            var produto = await _context.Produtos
                                             .Include(p => p.Categoria)
                                             .SingleOrDefaultAsync(p => p.Id == id);

            return produto;

        }

        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int CategoriaId)
        {
            var produtos = await _context.Produtos
                                 .Include(p => p.Categoria)
                                 .Where(p => p.CategoriaId == CategoriaId)
                                 .ToListAsync();

            return produtos;
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return categorias;
        }
    }
}
