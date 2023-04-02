using servicio_empresa_abc;
using Microsoft.EntityFrameworkCore;
using servicio_empresa_abc.Dto;
using servicio_empresa_abc.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebClienteDbContext>(options =>
{
    var config = builder.Configuration.GetConnectionString("Default");
    var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(config));
    options.UseMySql(config, serverVersion)
        .EnableSensitiveDataLogging(true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapPost("api/cliente", async (WebClienteDbContext context, ClienteDtoRequest request) =>
{
    var entity = new Cliente
    {
        nombre = request.nombre,
        apellido = request.apellido,
        numCedula = request.numCedula,
        tipoCanal = request.tipoCanal
    };

    await context.AddAsync(entity);
    await context.SaveChangesAsync();
    return Results.Ok(new
    {
        Id = entity.Id,
        Success = true
    });

});

app.Run();
