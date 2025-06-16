using ArtezaStudio.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Data
{
    public class ArtezaContext : DbContext
    {
        public ArtezaContext(DbContextOptions<ArtezaContext> options) : base(options)
        {
        }

        public DbSet<Publicacao> publicacoes { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Comentario> comentarios { get; set; }
        public DbSet<Curtida> curtidas { get; set; }
        public DbSet<Visualizacao> visualizacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Usuarios
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            // Configuração da entidade Publicacoes
            modelBuilder.Entity<Publicacao>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId);

            modelBuilder.Entity<Publicacao>()
                .HasMany(p => p.Comentarios)
                .WithOne(c => c.Publicacao)
                .HasForeignKey(c => c.PublicacaoId);

            modelBuilder.Entity<Publicacao>()
                .HasMany(p => p.Curtidas)
                .WithOne(c => c.Publicacao)
                .HasForeignKey(c => c.PublicacaoId);

            modelBuilder.Entity<Publicacao>()
                .HasMany(p => p.Visualizacoes)
                .WithOne(c => c.Publicacao)
                .HasForeignKey(c => c.PublicacaoId);

            // Configuração da entidade Comentarios
            modelBuilder.Entity<Comentario>()
                .HasOne(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId);

            modelBuilder.Entity<Comentario>()
                .HasOne(p => p.Publicacao)
                .WithMany()
                .HasForeignKey(p => p.PublicacaoId);

            // Configuração da entidade Curtidas
            modelBuilder.Entity<Curtida>()
                .HasOne(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId);

            modelBuilder.Entity<Curtida>()
                .HasOne(p => p.Publicacao)
                .WithMany()
                .HasForeignKey(p => p.PublicacaoId);

            // Configuração da entidade Visualizacoes
            modelBuilder.Entity<Visualizacao>()
                .HasOne(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId);

            modelBuilder.Entity<Visualizacao>()
                .HasOne(p => p.Publicacao)
                .WithMany()
                .HasForeignKey(p => p.PublicacaoId);
        }
    }
}
