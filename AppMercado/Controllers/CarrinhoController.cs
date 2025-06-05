using AppMercado.Models;
using Microsoft.AspNetCore.Mvc;
using AppMercado.Extensions;


namespace AppMercado.Controllers
{
    public class CarrinhoController : Controller
    {
        private CarrinhoViewModel GetCarrinho()
        {
            return HttpContext.Session.GetObjectFromJson<CarrinhoViewModel>("Carrinho") ?? new CarrinhoViewModel();
        }

        private void SaveCarrinho(CarrinhoViewModel carrinho)
        {
            HttpContext.Session.SetObjectAsJson("Carrinho", carrinho);
        }

        public IActionResult Index()
        {
            return PartialView("_Carrinho", GetCarrinho());
        }

        [HttpPost]
        public IActionResult AdicionarItem(int produtoId, int quantidade = 1)
        {
            if (quantidade <= 0)
                return BadRequest("Quantidade inválida");

            var produtos = new HomeController().GetProdutos();
            var produto = produtos.FirstOrDefault(p => p.Id == produtoId);

            if (produto == null)
                return NotFound("Produto não encontrado");

            if (!produto.Disponivel)
                return BadRequest("Produto indisponível");

            var carrinho = GetCarrinho();
            var itemExistente = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

            if (itemExistente != null)
            {
                itemExistente.IncrementarQuantidade(quantidade);
            }
            else
            {
                carrinho.Itens.Add(new CarrinhoItem 
                { 
                    Produto = produto, 
                    Quantidade = quantidade 
                });
            }

            SaveCarrinho(carrinho);
            return PartialView("_Carrinho", carrinho);
        }

        [HttpPost]
        public IActionResult RemoverItem(int produtoId)
        {
            var carrinho = GetCarrinho();
            var item = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

            if (item != null)
            {
                carrinho.Itens.Remove(item);
                SaveCarrinho(carrinho);
            }

            return PartialView("_Carrinho", carrinho);
        }

        [HttpPost]
        public IActionResult AtualizarQuantidade(int produtoId, int quantidade)
        {
            if (quantidade <= 0)
                return RemoverItem(produtoId);

            var carrinho = GetCarrinho();
            var item = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

            if (item != null)
            {
                item.Quantidade = quantidade;
                SaveCarrinho(carrinho);
            }

            return PartialView("_Carrinho", carrinho);
        }
    }
}