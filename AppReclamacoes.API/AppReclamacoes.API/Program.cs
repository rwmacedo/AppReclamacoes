using Microsoft.EntityFrameworkCore;
using AppReclamacoes.Infra.IoC;
using AppReclamacoes.Application.Mappings;
using AppReclamacoes.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Exibir a string de conexão para depuração
Console.WriteLine($"SQL_CONNECTION_STRING: {Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")}");

// Adicionando serviços ao container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Pegando a string de conexão do ambiente
var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")
    ?? throw new InvalidOperationException("A string de conexão SQL não foi configurada corretamente.");

// Certifique-se de passar a string de conexão corretamente para o contexto do EF
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Adicionando infraestrutura
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Aplicando migrações durante a inicialização do aplicativo
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Aplica as migrações automaticamente
}

// Configurando o Swagger para documentação da API
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty;
});

// Configurar a porta para o Heroku
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

// Habilitar CORS
app.UseCors("AllowAll");

// Rotas e middleware padrão
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reclamacoes}/{action=Index}/{id?}");

app.Run();
