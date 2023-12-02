using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.API.Entities
{
    public class Produto : Entity
    {
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Descricao { get; set; } = string.Empty;

        [MaxLength(200)]
        public string ImagemUrl { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        // Propriedade de chave estrangeira de categoria
        public int CategoriaId { get; set; }

        // Propriedade de navegação do EF
        public Categoria? Categoria { get; set; }

        // Propriedade de navegação de coleção
        public ICollection<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();
    }
}
