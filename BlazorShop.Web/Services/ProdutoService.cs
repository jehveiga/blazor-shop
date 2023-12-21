using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services.Interfaces;
using System.Net;
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

        public async Task<ProdutoDto> GetItemById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/produtos/{id}");

                if (response.IsSuccessStatusCode) // Status Code 200-299
                {
                    if (response.StatusCode == HttpStatusCode.NoContent) // Status 204
                        return default(ProdutoDto);

                    return await response.Content.ReadFromJsonAsync<ProdutoDto>(); // Retorna o valor desseralizado Json como objeto produto
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro a obter produto pelo id= {id} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {

                _logger.LogError($"Erro a obter produto pelo id= {id}");
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/produtos/getitens/{categoriaId}/porcategoria");

                if (response.IsSuccessStatusCode) // Status Code 200-299
                {
                    if (response.StatusCode == HttpStatusCode.NoContent) // Status 204
                        return Enumerable.Empty<ProdutoDto>();

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDto>>(); // Retorna o valor desseralizado Json como objeto produto
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategorias()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/produtos/getcategorias");

                if (response.IsSuccessStatusCode) // Status Code 200-299
                {
                    if (response.StatusCode == HttpStatusCode.NoContent) // Status 204
                        return Enumerable.Empty<CategoriaDto>();

                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaDto>>(); // Retorna o valor desseralizado Json como objeto produto
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
