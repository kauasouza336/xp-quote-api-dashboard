async function consultarAcao() {
    const input = document.getElementById('tickerInput');
    const ticker = input.value.toUpperCase();
    // Verifique se o endereço (localhost) é o mesmo do seu Swagger!
    const url = `https://localhost:7121/api/Stocks/${ticker}`;
    try {
        const resposta = await fetch(url);
        if (!resposta.ok) {
            alert("Ação não encontrada!");
            return;
        }
        const dados = await resposta.json();
        // Referências dos elementos HTML
        const elementoPreco = document.getElementById('precoAcao');
        const elementoNome = document.getElementById('nomeAcao');
        const elementoHora = document.getElementById('horaAcao');
        const divResultado = document.getElementById('resultado');
        // Preenche os dados
        elementoNome.innerText = dados.nome;
        elementoPreco.innerText = `R$ ${dados.preco.toFixed(2)}`;
        elementoHora.innerText = dados.horario;
        // Lógica de Cores (O toque profissional)
        if (dados.preco > 80) {
            elementoPreco.style.color = "#2ecc71"; // Verde se for caro/subindo
        }
        else {
            elementoPreco.style.color = "#e74c3c"; // Vermelho se for barato/caindo
        }
        divResultado.style.display = 'block';
    }
    catch (erro) {
        console.error("Erro ao conectar na API:", erro);
        alert("Erro: Verifique se o Backend C# está rodando!");
    }
}
