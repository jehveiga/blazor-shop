using BlazorShop.API.Interfaces;
using BlazorShop.API.Mappings;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [Route("api/carrinho/compras")]
    [ApiController]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
        private readonly IProdutoRepository _produtoRepository;

        private ILogger<CarrinhoCompraController> _logger;

        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoCompraRepository,
                                        IProdutoRepository produtoRepository,
                                        ILogger<CarrinhoCompraController> logger)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        [HttpGet("{usuarioId:int}/getitens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetItens([FromRoute] int usuarioId)
        {
            try
            {
                var carrinhoItens = await _carrinhoCompraRepository.GetItens(usuarioId);
                if (carrinhoItens is null)
                    return NoContent(); // 204 Status Code

                var produtos = await _produtoRepository.GetItens();
                if (produtos is null)
                    throw new Exception("não existem produtos...");

                var carrinhosItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
                return Ok(carrinhosItensDto);
            }
            catch (Exception)
            {
                _logger.LogError("## Erro ao obter itens do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha interna do servidor!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> GetItem([FromRoute] int id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.GetItemById(id);
                if (carrinhoItem is null)
                    return NotFound("Item não encontrado"); // 404 Status Code

                var produto = await _produtoRepository.GetItemById(id);
                if (produto is null)
                    return NotFound("Item não existe na fonte de dados");

                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return Ok(carrinhoItemDto);
            }
            catch (Exception)
            {
                _logger.LogError($"## Erro ao obter o item {id} do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha interna do servidor!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> PostItem([FromBody] CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await _carrinhoCompraRepository.AdicionaItem(carrinhoItemAdicionaDto);

                if (novoCarrinhoItem is null)
                    return NoContent(); // Status 204

                var produto = await _produtoRepository.GetItemById(novoCarrinhoItem.ProdutoId);

                if (produto is null)
                    throw new Exception($"Produto não localizado (Id:({carrinhoItemAdicionaDto.ProdutoId}))");

                var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItemParaDto(produto);

                return CreatedAtAction(nameof(GetItem), new { id = novoCarrinhoItemDto.Id }, novoCarrinhoItemDto);
            }
            catch (Exception)
            {
                _logger.LogError($"## Erro ao criar um novo item no carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha interna do servidor!");
            }
        }
    }
}
