
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CONECTA_BRASIL.Models
{
    public class PublicacaoCategoria
    {
        [Key]
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public required Categoria Categoria { get; set; }

        public int PublicacaoId { get; set; }
        [ForeignKey("PublicacaoId")]
        public required Publicacao Publicacao { get; set; }
    }
}
