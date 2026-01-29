using Microsoft.EntityFrameworkCore;

namespace xp_quote_api_dashboard.Data
{
    // Esta classe controla a conexão com o banco de dados
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Isso cria a tabela "Cotacoes" no seu SQL
        public DbSet<Cotacao> Cotacoes { get; set; }
    }

    // Define quais informações vamos salvar (Ticker, Preço e Hora)
    public class Cotacao
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public double Preco { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}