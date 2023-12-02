namespace BlazorShop.API.Entities
{
    public class CarrinhoItem : Entity
    {
        // Propriedade de chave estrangeira de categoria
        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }


        // Propriedade de navegação do EF
        public Carrinho? Carrinho { get; set; }
        public Produto? Produto { get; set; }
    }
}
