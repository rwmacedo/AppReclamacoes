using AppReclamacoes.Domain.Interfaces;
using AppReclamacoes.Infra.Data.Context;
using AppReclamacoes.Infra.Data.Repositories;
using AppReclamacoes.Application.Interfaces;
using AppReclamacoes.Application.Services;
using AppReclamacoes.Application.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppReclamacoes.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IReclamacaoRepository, ReclamacaoRepository>();           
            services.AddScoped<IProdutoRepository, ProdutoRepository>();           

            services.AddScoped<IReclamacaoService, ReclamacaoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            return services;
        }
    }
}
