using BlazorShop.API.Entities;

namespace BlazorShop.API.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetItens();
        Task<Produto> GetItem(int id);
        Task<IEnumerable<Produto>> GetItensPorCategoria(int CategoriaId);
    }
}
