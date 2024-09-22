using Microsoft.EntityFrameworkCore;
using AppReclamacoes.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace AppReclamacoes.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Reclamacao> Reclamacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; } 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
