using BlazorShop.API.Interfaces;
using BlazorShop.API.Mappings;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();

                var produtosDto = produtos.ConverterProdutosParaDto();

                return Ok(produtosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha interna do servidor!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDto>> GetItemById([FromRoute] int id)
        {
            try
            {
                var produto = await _produtoRepository.GetItemById(id);

                if (produto is null)
                    return NotFound("Produto não localizado");

                var produtoDto = produto.ConverterProdutoParaDto();
                return Ok(produtoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha interna do servidor!");
            }
        }

        [HttpGet("getitens/{categoriaId:int}/porcategoria")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria([FromRoute] int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);

                var produtosDto = produtos.ConverterProdutosParaDto();
                return Ok(produtosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha interna do servidor!");
            }
        }
    }
}
