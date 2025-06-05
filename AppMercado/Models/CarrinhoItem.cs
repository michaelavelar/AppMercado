namespace AppMercado.Models
{
    public class CarrinhoItem
    {
        public Produto Produto { get; set; } = null!; 
        public int Quantidade { get; set; }

        public decimal Subtotal => Produto.Preco * Quantidade;
        
        public void IncrementarQuantidade(int quantidade = 1)
        {
            Quantidade += quantidade;
        }
        
        public bool DecrementarQuantidade(int quantidade = 1)
        {
            if (Quantidade - quantidade <= 0)
                return false;
            
            Quantidade -= quantidade;
            return true;
        }
    }
}