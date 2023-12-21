using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetItens();
        Task<ProdutoDto> GetItemById(int id);
        Task<IEnumerable<ProdutoDto>> GetItensPorCategoria(int categoriaId);
        Task<IEnumerable<CategoriaDto>> GetCategorias();
    }
}
