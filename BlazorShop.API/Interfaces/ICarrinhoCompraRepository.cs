using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);
        Task<CarrinhoItem> DeletaItem(int id);
        Task<CarrinhoItem> GetItemById(int id);
        Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId);
    }
}
