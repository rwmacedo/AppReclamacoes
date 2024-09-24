using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace AppReclamacoes.Infra.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Verifica a variável de ambiente
            //var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
            var connectionString= Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") 
            ?? throw new InvalidOperationException("A string de conexão SQL não foi configurada corretamente.");


           if (string.IsNullOrEmpty(connectionString))
           {
                // Caso a variável não exista, usa o appsettings.json para o ambiente local
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../AppReclamacoes.API/AppReclamacoes.API"))
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
