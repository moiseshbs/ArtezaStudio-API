using ArtezaStudio.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Data
{
    public class ArtezaContext : DbContext
    {
        public ArtezaContext(DbContextOptions<ArtezaContext> options) : base(options)
        {
        }

        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Visualizacao> Visualizacoes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PublicacaoTag> PublicacaoTags { get; set; }
        public DbSet<UsuarioSeguidor> usuarioSeguidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Usuarios
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            // Configuração da entidade UsuarioSeguidor
            modelBuilder.Entity<UsuarioSeguidor>()
                .HasKey(us => new { us.SeguidorId, us.SeguidoId });

            modelBuilder.Entity<UsuarioSeguidor>()
                .HasOne(us => us.Seguidor)
                .WithMany()
                .HasForeignKey(us => us.SeguidorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioSeguidor>()
                .HasOne(us => us.Seguido)
                .WithMany()
                .HasForeignKey(us => us.SeguidoId)
                .OnDelete(DeleteBehavior.Restrict);

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

            // Configuração da entidade Tags
            modelBuilder.Entity<Tag>().ToTable("tags");

            // Configuração da entidade PublicacaoTags
            modelBuilder.Entity<PublicacaoTag>()
                .HasKey(pt => new { pt.PublicacaoId, pt.TagId });

            modelBuilder.Entity<PublicacaoTag>()
                .HasOne(pt => pt.Publicacao)
                .WithMany(p => p.PublicacaoTags)
                .HasForeignKey(pt => pt.PublicacaoId);

            modelBuilder.Entity<PublicacaoTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PublicacaoTags)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
