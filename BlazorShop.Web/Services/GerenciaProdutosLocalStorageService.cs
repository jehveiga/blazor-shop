using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services.Interfaces;

namespace BlazorShop.Web.Services
{
    public class GerenciaProdutosLocalStorageService : IGerenciaProdutosLocalStorageService
    {
        // chave que será usada para identificar a coleção que será adicionada, obtida ou excluida do Local Storage
        private const string _key = "ProdutoCollection";

        private readonly ILocalStorageService _localStorageService;
        private readonly IProdutoService _produtoService;

        public GerenciaProdutosLocalStorageService(ILocalStorageService localStorageService, IProdutoService produtoService)
        {
            _localStorageService = localStorageService;
            _produtoService = produtoService;
        }

        // Tentará obter a lista de produtos no local storage se não conseguir Efetuará um Get do serviço
        // e usará o método Set para adicionar os itens no local storage
        public async Task<IEnumerable<ProdutoDto>> GetCollection()
        {
            return await _localStorageService.GetItemAsync<IEnumerable<ProdutoDto>>(_key)
                            ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(_key);
        }

        private async Task<IEnumerable<ProdutoDto>> AddCollection()
        {
            var produtosCollection = await _produtoService.GetItens();
            if (produtosCollection != null)
                await _localStorageService.SetItemAsync(_key, produtosCollection);

            return produtosCollection;
        }
    }
}
