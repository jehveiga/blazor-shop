using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface ICarrinhoCompraService
    {
        Task<IList<CarrinhoItemDto>> GetItens(int usuarioId);

        Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
    }
}
