using Microsoft.AspNetCore.Mvc;
using novo_projeto.Models;
using XP.Api.Data;   // Verifique se o nome aqui está igual à sua pasta Data
using XP.Api.Models; // Verifique se o nome aqui está igual à sua pasta Models

namespace XP.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AcoesController : ControllerBase
	{
		private readonly AppDbContext _context = new AppDbContext();

		// Esse método recebe o que o seu JavaScript enviar
		[HttpPost]
		public IActionResult Salvar([FromBody] Acao novaAcao)
		{
			if (novaAcao == null) return BadRequest();

			_context.Acoes.Add(novaAcao); // Coloca no molde
			_context.SaveChanges();      // Salva no arquivo SQL

			return Ok(new { mensagem = "Ação gravada no banco com sucesso!" });
		}

		// Esse método serve para o JavaScript listar as ações que já estão no banco
		[HttpGet("{symbol}")] // Esse aqui busca e salva uma ação específica
		public IActionResult BuscarESalvar(string symbol)
		{
			// 1. Simulação do preço (ou sua lógica de busca atual)
			decimal precoAtual = 110.50m;

			// 2. Salva no Banco de Dados
			var novaAcao = new Acao
			{
				Simbolo = symbol.ToUpper(),
				NomeEmpresa = "Empresa via API",
				Preco = precoAtual,
				DataConsulta = DateTime.Now
			};

			_context.Acoes.Add(novaAcao);
			_context.SaveChanges();

			return Ok(novaAcao);
		}
