using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface IGerenciaCarrinhoItensLocalStorageService
    {
        Task<IEnumerable<CarrinhoItemDto>> GetCollection();
        Task SaveCollection(IEnumerable<CarrinhoItemDto> carrinhoItensDto);
        Task RemoveCollection();
    }
}
