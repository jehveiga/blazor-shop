namespace BlazorShop.API.Entities
{
    public class CarrinhoItem : Entity
    {
        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
