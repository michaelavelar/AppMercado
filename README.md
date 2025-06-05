APPMercado - Sistema de Carrinho de Compras
📝 Descrição
Aplicativo de e-commerce simples com categorias de produtos (Frutas e Limpeza) e carrinho de compras interativo.

🛠️ Funcionalidades Principais
Navegação por abas entre categorias de produtos

Adicionar produtos ao carrinho com quantidade ajustável

Remover itens do carrinho

Ajustar quantidades diretamente no carrinho

Exibição de produtos indisponíveis (não podem ser adicionados)

🚀 Como Executar
Certifique-se de ter o .NET 8 SDK instalado

Clone o repositório

Execute no terminal:

bash
dotnet run
Acesse no navegador:

http://localhost:5145
🧩 Tecnologias Utilizadas
Backend:

.NET 8

ASP.NET Core MVC

C#

Frontend:

HTML5

CSS3

JavaScript

Bootstrap 5

AJAX para atualizações dinâmicas

🗂️ Estrutura do Projeto
AppMercado/
├── Controllers/
│   ├── HomeController.cs
│   ├── ProdutoController.cs
│   └── CarrinhoController.cs
├── Models/
│   ├── Produto.cs
│   ├── CarrinhoItem.cs
│   └── CarrinhoViewModel.cs
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── _ListaProdutos.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _Navbar.cshtml
│       └── _Carrinho.cshtml
└── wwwroot/
    ├── css/
    │   └── site.css
    └── js/
        └── site.js
🔧 Como Funciona
Exibição de Produtos:

Os produtos são carregados e separados por categorias

Produtos indisponíveis são marcados e não podem ser adicionados

Carrinho de Compras:

Itens são armazenados na sessão do navegador

Quantidades podem ser ajustadas com botões (+/-) ou digitando valores

Total é calculado automaticamente

Interações:

Todas as operações no carrinho são feitas via AJAX, sem recarregar a página

📌 Observações
Projeto desenvolvido como teste para vaga de Analista Programador

Arquitetura seguindo o padrão MVC

Componentização de views parciais para reutilização de código

![Captura de tela 2025-06-05 175654](https://github.com/user-attachments/assets/8975072c-1c26-41b5-a820-1e1e28ee7fd8)
