
using System.ComponentModel.DataAnnotations;
using static CONECTA_BRASIL.Models.Pessoa;

namespace CONECTA_BRASIL.Models
{
    public class Publicacao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo requerido.")]
        [Display(Name = "Titulo")]
        public string? Titulo { get; set; }

        [Display(Name = "Conteudo")]
        public required string Conteudo { get; set; }

        public int CriadorId { get; set; }
        public Usuario? Criador { get; set; }

        public required List<PublicacaoCategoria> PublicacaoCategorias { get; set; } = new List<PublicacaoCategoria>();

    }
}
