using System.ComponentModel.DataAnnotations;

namespace BlazorShop.API.Entities
{
    public class Usuario : Entity
    {
        [MaxLength(100)]
        public string NomeUsuario { get; set; } = string.Empty;
        public Carrinho? Carrinho { get; set; }
    }
}
