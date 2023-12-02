namespace BlazorShop.API.Entities
{
    public class Carrinho : Entity
    {
        public int UsuarioId { get; set; }


        // Propriedade de navegação de coleção
        public ICollection<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();

    }
}
