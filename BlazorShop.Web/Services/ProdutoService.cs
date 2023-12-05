using BlazorShop.Models.DTOs;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;
        private ILogger<ProdutoDto> _logger;

        public ProdutoService(HttpClient httpClient, ILogger<ProdutoDto> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<ProdutoDto>> GetItens()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produtos");

                return produtosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos : api/produtos ");
                throw;
            }

        }
    }
}
