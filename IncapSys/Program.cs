using IncapSys.Interfaces.Incapacidades;
using IncapSys.Interfaces.Rol;
using IncapSys.Interfaces.Usuarios;
using IncapSys.Mapper.Usuarios;
using IncapSys.Models;
using IncapSys.Models.Incapacidades;
using IncapSys.Models.Rol;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories.Incapacidades;
using IncapSys.Repositories.Rol;
using IncapSys.Repositories.Usuarios;
using IncapSys.Services.IncapacidadesServices;
using IncapSys.Services.RolServices;
using IncapSys.Services.UsuariosServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
// usuarios repository
builder.Services.AddScoped<IUsuariosRepository<Empleados>, UsuarioRepositoryService>();

//incapacidades interface
builder.Services.AddScoped<IIncapacidadesService, IncapacidadesServices>();
//repository incapacidades
builder.Services.AddScoped<IIncapacidadesRepository<DescripcionIncapacidad>, IncapacidadesRepositoryService>();

//roles interface
builder.Services.AddScoped<IRolService, RolService>();
//repository roles
builder.Services.AddScoped<IRolRepository<Roles>, RolRepositoryService>();

builder.Services.AddAutoMapper(typeof(MappingProfileUsuarios));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
