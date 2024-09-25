


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SistemaVendasApi.Configuration;
using Vendas.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API 123Vendas",
        Version = "v1",
        Description = "Documentação do sistema 123Vendas",
        Contact = new OpenApiContact
        {
            Name = "123Vendas",
            Email = "suporte@vendas.com"
        }
    });
});

//Adicionando injeções de dependências no projeto.
builder.Services.AddDependencyInjectionConfiguration();

// Configuração do contexto da aplicação e sua connection string.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
}); 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API 123Vendas v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
