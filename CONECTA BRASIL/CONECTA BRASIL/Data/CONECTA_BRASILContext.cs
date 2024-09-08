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
        public DbSet<CONECTA_BRASIL.Models.Instituicao> Instituição { get; set; } = default!;
        public DbSet<CONECTA_BRASIL.Models.Publicacao> Publicacao { get; set; } = default!;
    }
}
