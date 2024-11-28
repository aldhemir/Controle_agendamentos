using Microsoft.EntityFrameworkCore;
using ApiAgendamentos.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurações de banco de dados PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços necessários
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger para documentação
    app.UseSwaggerUI(c =>
    {
        // Configura a URL para acessar a documentação da API no Swagger
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Agendamentos API V1");
        c.RoutePrefix = string.Empty; // Exibe o Swagger UI na raiz (localhost:5122)
    });
}

// Middleware de autorização
app.UseAuthorization();

// Mapear controladores para as rotas da API
app.MapControllers();

// Inicia o aplicativo
app.Run();
