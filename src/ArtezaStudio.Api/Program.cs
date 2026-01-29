using ArtezaStudio.Infrastructure.Data;
using ArtezaStudio.Api.Middlewares;
using ArtezaStudio.Infrastructure.Repositories;
using ArtezaStudio.Domain.Interfaces;
using ArtezaStudio.Application.Services;
using ArtezaStudio.Application.Services.Interfaces;
using ArtezaStudio.Application.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ArtezaStudio.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
builder.Services.AddScoped<IPublicacaoService, PublicacaoService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<ICurtidaRepository, CurtidaRepository>();
builder.Services.AddScoped<ICurtidaService, CurtidaService>();
builder.Services.AddScoped<IVisualizacaoRepository, VisualizacaoRepository>();
builder.Services.AddScoped<IVisualizacaoService, VisualizacaoService>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUsuarioSeguidorRepository, UsuarioSeguidorRepository>();
builder.Services.AddScoped<IUsuarioSeguidorService, UsuarioSeguidorService>();

builder.Services.AddSingleton<ISenhaHashService, SenhaHashService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PublicacaoCreateDtoValidator>();
builder.Services.AddDbContext<ArtezaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))
    ));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();