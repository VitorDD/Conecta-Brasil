using System.ComponentModel.DataAnnotations;

namespace CONECTA_BRASIL.Models
{
    public class PagInicial
    {
        [Key]
        public int Id { get; set; }
        public required IEnumerable<Publicacao> Publicacoes { get; set; }
    }
}
