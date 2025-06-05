namespace AppMercado.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; 
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = string.Empty; 
        public bool Disponivel { get; set; }
    }
}