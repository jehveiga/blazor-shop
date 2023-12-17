using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services.Interfaces
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDto>> GetItens(int usuarioId);

        Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItemDto> DeletaItem(int id);

    }
}
