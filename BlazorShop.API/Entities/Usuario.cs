namespace BlazorShop.API.Entities
{
    public class Usuario : Entity
    {
        public string NomeUsuario { get; set; } = string.Empty;
        public Carrinho? Carrinho { get; set; }
    }
}
