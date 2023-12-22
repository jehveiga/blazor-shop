using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface IGerenciaProdutosLocalStorageService
    {
        Task<IEnumerable<ProdutoDto>> GetCollection();
        Task RemoveCollection();
    }
}
