using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services.Interfaces;

namespace BlazorShop.Web.Services
{
    public class GerenciaCarrinhoItensLocalStorageService : IGerenciaCarrinhoItensLocalStorageService
    {
        private const string _key = "CarrinhoItemCollection";

        private readonly ILocalStorageService _localStorageService;
        private readonly ICarrinhoCompraService _carrinhoCompraService;

        public GerenciaCarrinhoItensLocalStorageService(ILocalStorageService localStorageService, ICarrinhoCompraService carrinhoCompraService)
        {
            _localStorageService = localStorageService;
            _carrinhoCompraService = carrinhoCompraService;
        }

        public async Task<IEnumerable<CarrinhoItemDto>> GetCollection()
        {
            return await _localStorageService.GetItemAsync<IEnumerable<CarrinhoItemDto>>(_key)
                ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(_key);
        }

        public async Task SaveCollection(IEnumerable<CarrinhoItemDto> carrinhoItensDto)
        {
            await _localStorageService.SetItemAsync(_key, carrinhoItensDto);
        }

        // obtem os dados do servidor e armazena no Local Storage
        private async Task<IEnumerable<CarrinhoItemDto>> AddCollection()
        {
            var carrinhoCompraCollection = await _carrinhoCompraService.GetItens(UsuarioLogado.UsuarioId);
            if (carrinhoCompraCollection != null)
                await _localStorageService.SetItemAsync(_key, carrinhoCompraCollection);

            return carrinhoCompraCollection;
        }
    }
}
