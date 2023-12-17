using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoCompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CarrinhoItemDto>> GetItens(int usuarioId)
        {
            try
            {
                //envia um request GET para a uri da API CarrinhoCompra
                var response = await _httpClient.GetAsync($"api/carrinho/compras/{usuarioId}/getitens");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return Enumerable.Empty<CarrinhoItemDto>().ToList();

                    return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/carrinho/compras", carrinhoItemAdicionaDto);

                if (response.IsSuccessStatusCode)// status code entre 200 a 299
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        // retorna o valor "padrão" ou vazio
                        // para uma objeto do tipo carrinhoItemDto
                        return default(CarrinhoItemDto);
                    }
                    //le o conteudo HTTP e retorna o valor resultante
                    //da serialização do conteudo JSON para o objeto Dto
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                else
                {
                    //serializa o conteudo HTTP como uma string
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
