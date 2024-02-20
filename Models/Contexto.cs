using Microsoft.EntityFrameworkCore;
using Projeto_Final.Models;

namespace Projeto_Final.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<VendaHasProduto> VendaHasProduto { get; set; }

    }
}
