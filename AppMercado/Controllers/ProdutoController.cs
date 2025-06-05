using AppMercado.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AppMercado.Controllers
{
    public class ProdutoController : Controller
    {
       
        
        private List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Maçã", Preco = 3.50m, Categoria = "Frutas", Disponivel = true },
            new Produto { Id = 2, Nome = "Banana", Preco = 2.80m, Categoria = "Frutas", Disponivel = true },
            new Produto { Id = 3, Nome = "Laranja", Preco = 4.20m, Categoria = "Frutas", Disponivel = false },
            new Produto { Id = 4, Nome = "Detergente", Preco = 5.90m, Categoria = "Limpeza", Disponivel = true },
            new Produto { Id = 5, Nome = "Sabão em Pó", Preco = 12.50m, Categoria = "Limpeza", Disponivel = true },
            new Produto { Id = 6, Nome = "Desinfetante", Preco = 8.75m, Categoria = "Limpeza", Disponivel = false },
            new Produto { Id = 7, Nome = "Álcool", Preco = 6.80m, Categoria = "Limpeza", Disponivel = true },
            new Produto { Id = 8, Nome = "Melancia", Preco = 15.00m, Categoria = "Frutas", Disponivel = true },
            new Produto { Id = 9, Nome = "Abacaxi", Preco = 7.00m, Categoria = "Frutas", Disponivel = true }
        };

        public IActionResult Index()
        {
            return View(_produtos);
        }

        public IActionResult PorCategoria(string categoria)
        {
            var produtos = _produtos
                .Where(p => p.Categoria == categoria)
                .ToList();

            return View("Index", produtos);
        }
    }
}
