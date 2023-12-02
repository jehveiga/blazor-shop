using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.API.Entities
{
    public class Categoria : Entity
    {
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        public string IconCSS { get; set; } = string.Empty;

        // Propriedade de navegação de coleção
        public ICollection<Produto> Produtos { get; set; } = new Collection<Produto>();
    }
}
