namespace BlazorShop.API.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
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
