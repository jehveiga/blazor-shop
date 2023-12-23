using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface IGerenciaCarrinhoItensLocalStorageService
    {
        Task<List<CarrinhoItemDto>> GetCollection();
        Task SaveCollection(IEnumerable<CarrinhoItemDto> carrinhoItensDto);
        Task RemoveCollection();
    }
}
