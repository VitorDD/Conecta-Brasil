using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CONECTA_BRASIL.Models;

namespace CONECTA_BRASIL.Data
{
    public class CONECTA_BRASILContext : DbContext
    {
        public CONECTA_BRASILContext (DbContextOptions<CONECTA_BRASILContext> options)
            : base(options)
        {
        }

        public DbSet<CONECTA_BRASIL.Models.Pessoa> Pessoa { get; set; } = default!;
<<<<<<< Updated upstream
        public DbSet<CONECTA_BRASIL.Models.Instituicao> Instituição { get; set; } = default!;
        public DbSet<CONECTA_BRASIL.Models.Publicacao> Publicacao { get; set; } = default!;
=======
        public DbSet<CONECTA_BRASIL.Models.Instituicao> Instituicao { get; set; } = default!;
        public DbSet<CONECTA_BRASIL.Models.Publicacao> Publicacoes { get; set; } = default!;
        public DbSet<CONECTA_BRASIL.Models.Categoria> Categorias { get; set; } = default!;
        public DbSet<CONECTA_BRASIL.Models.PublicacaoCategoria> PublicacaoCategorias { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PublicacaoCategoria>()
           .HasOne(pc => pc.Publicacao)
           .WithMany(p => p.PublicacaoCategorias)
           .HasForeignKey(pc => pc.PublicacaoId);

            modelBuilder.Entity<PublicacaoCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany(c => c.PublicacaoCategorias)
                .HasForeignKey(pc => pc.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
>>>>>>> Stashed changes
    }
}
