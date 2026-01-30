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
using ArtezaStudio.Api.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

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
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton<ISenhaHashService, SenhaHashService>();
builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Arteza Studio API",
        Version = "v1",
        Description = "API para rede social de artistas"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token Bearer: "
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PublicacaoCreateDtoValidator>();

builder.Services.AddDbContext<ArtezaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))
    ));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings?.Issuer,
        ValidAudience = jwtSettings?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.SecretKey ?? "")),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();