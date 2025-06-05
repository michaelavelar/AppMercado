document.addEventListener('DOMContentLoaded', function() {
    document.addEventListener('click', function(e) {
        // Adicionar ao carrinho
        if (e.target.classList.contains('btn-adicionar')) {
            const produtoId = e.target.getAttribute('data-produto-id');
            const quantidade = e.target.closest('.input-group').querySelector('.quantidade-input').value;
            adicionarAoCarrinho(produtoId, quantidade);
        }
        
        // Incrementar quantidade na lista
        if (e.target.classList.contains('btn-plus')) {
            const input = e.target.closest('.input-group').querySelector('.quantidade-input');
            input.value = parseInt(input.value) + 1;
        }
        
        // Decrementar quantidade na lista
        if (e.target.classList.contains('btn-minus')) {
            const input = e.target.closest('.input-group').querySelector('.quantidade-input');
            if (parseInt(input.value) > 1) {
                input.value = parseInt(input.value) - 1;
            }
        }
        
        // Incrementar quantidade no carrinho
        if (e.target.classList.contains('btn-carrinho-plus')) {
            const produtoId = e.target.getAttribute('data-produto-id');
            const input = e.target.closest('.input-group').querySelector('.quantidade-carrinho');
            input.value = parseInt(input.value) + 1;
            input.dispatchEvent(new Event('change'));
        }
        
        // Decrementar quantidade no carrinho
        if (e.target.classList.contains('btn-carrinho-minus')) {
            const produtoId = e.target.getAttribute('data-produto-id');
            const input = e.target.closest('.input-group').querySelector('.quantidade-carrinho');
            input.value = parseInt(input.value) - 1;
            input.dispatchEvent(new Event('change'));
        }
        
        // Remover item do carrinho
        if (e.target.classList.contains('btn-remover')) {
            const produtoId = e.target.getAttribute('data-produto-id');
            removerDoCarrinho(produtoId);
        }
    });
    
    // Alteração direta do input no carrinho
    document.addEventListener('change', function(e) {
        if (e.target.classList.contains('quantidade-carrinho')) {
            const produtoId = e.target.getAttribute('data-produto-id');
            const novaQuantidade = parseInt(e.target.value);
            atualizarQuantidadeNoCarrinho(produtoId, novaQuantidade);
        }
    });
    
    // Carrega o carrinho ao iniciar
    carregarCarrinho();
});

function carregarCarrinho() {
    fetch('/Carrinho/Index')
        .then(response => response.text())
        .then(html => {
            document.getElementById('carrinhoContainer').innerHTML = html;
        });
}

function adicionarAoCarrinho(produtoId, quantidade) {
    fetch('/Carrinho/AdicionarItem', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: `produtoId=${produtoId}&quantidade=${quantidade}`
    })
    .then(response => {
        if (!response.ok) {
            return response.text().then(text => { throw new Error(text) });
        }
        return response.text();
    })
    .then(html => {
        document.getElementById('carrinhoContainer').innerHTML = html;
        mostrarNotificacao('Produto adicionado ao carrinho!', 'success');
    })
    .catch(error => {
        mostrarNotificacao(error.message, 'danger');
    });
}

function removerDoCarrinho(produtoId) {
    fetch('/Carrinho/RemoverItem', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: `produtoId=${produtoId}`
    })
    .then(response => response.text())
    .then(html => {
        document.getElementById('carrinhoContainer').innerHTML = html;
        mostrarNotificacao('Produto removido do carrinho!', 'warning');
    });
}

function atualizarQuantidadeNoCarrinho(produtoId, quantidade) {
    fetch('/Carrinho/AtualizarQuantidade', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: `produtoId=${produtoId}&quantidade=${quantidade}`
    })
    .then(response => response.text())
    .then(html => {
        document.getElementById('carrinhoContainer').innerHTML = html;
    });
}

function mostrarNotificacao(mensagem, tipo) {
    const notificacao = document.createElement('div');
    notificacao.className = `alert alert-${tipo} position-fixed top-0 end-0 m-3`;
    notificacao.style.zIndex = '2000';
    notificacao.textContent = mensagem;
    document.body.appendChild(notificacao);
    
    setTimeout(() => {
        notificacao.remove();
    }, 3000);
}