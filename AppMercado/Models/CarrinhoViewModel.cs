namespace AppMercado.Models
{
    public class CarrinhoViewModel
    {
        public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();
        public decimal Total => Itens.Sum(i => i.Produto.Preco * i.Quantidade);
    }
}