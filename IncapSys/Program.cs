using IncapSys.Interfaces.Incapacidades;
using IncapSys.Interfaces.Usuarios;
using IncapSys.Models;
using IncapSys.Models.Incapacidades;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories;
using IncapSys.Services.IncapacidadesServices;
using IncapSys.Services.UsuariosServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
});

//usuarios interface
builder.Services.AddScoped<IUsuarioService, UsuariosService>();
builder.Services.AddScoped<IUsuariosRepository<Empleados>, UsuarioRepositoryService>();

//incapacidades interface
builder.Services.AddScoped<IIncapacidadesService, IncapacidadesService>();
builder.Services.AddScoped<IIncapacidadesRepository<DescripcionIncapacidad>, IncapacidadRepositoryService>();

builder.Services.AddAutoMapper(typeof(MappingProfileUsuarios)); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
