using AppReclamacoes.Infra.IoC;
using AppReclamacoes.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty;  
});

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();  

app.Run();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reclamacoes}/{action=Index}/{id?}");

app.Run();
