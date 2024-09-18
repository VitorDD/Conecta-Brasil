
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CONECTA_BRASIL.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public required string Tipo { get; set; }

        public List<PublicacaoCategoria>? PublicacaoCategorias { get; set; }
    }
}
