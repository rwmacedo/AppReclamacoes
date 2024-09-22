using AppReclamacoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppReclamacoes.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
             builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeProduto).HasMaxLength(100).IsRequired();

            // Inserir dados iniciais
            builder.HasData(
                new Produto(1, "Conta Depósito"),
                new Produto(2, "Câmbio"),
                new Produto(3, "Habitação"),
                new Produto(4, "Penhor"),
                new Produto(5, "Ações Online"),
                new Produto(6, "Seguro"),
                new Produto(7, "Cartão de Crédito"),
                new Produto(8, "Fundos de Investimento"),
                new Produto(9, "Consignado")
            );
        }
    }
}
