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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Publicacao
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            // Configuração da entidade Usuario
            modelBuilder.Entity<Publicacao>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId);

            modelBuilder.Entity<Publicacao>()
                .HasMany(p => p.Comentarios)
                .WithOne(c => c.Publicacao)
                .HasForeignKey(c => c.PublicacaoId);

            // Configuração da entidade Comentario
            modelBuilder.Entity<Comentario>()
                .HasOne(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId);

            modelBuilder.Entity<Comentario>()
                .HasOne(p => p.Publicacao)
                .WithMany()
                .HasForeignKey(p => p.PublicacaoId);
        }
    }
}
