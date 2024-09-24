using System.ComponentModel.DataAnnotations;
using static CONECTA_BRASIL.Models.Pessoa;

namespace CONECTA_BRASIL.Models
{
    public class Publicacao
    {
        public enum Categorias
        {
            Noticias,
            Esportes,
            Eventos,
            Avisos
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo requerido.")]
        [Display(Name = "Titulo")]
        public required string Titulo { get; set; }

        [Display(Name = "Categoria")]
        public Categorias Categoria { get; set; }

        [Display(Name = "Conteudo")]
        public required string Conteudo { get; set; }
<<<<<<< Updated upstream
=======

        public int CriadorId { get; set; }
        public Usuario? Criador { get; set; }

        public required List<PublicacaoCategoria> PublicacaoCategorias { get; set; } = new List<PublicacaoCategoria>();

        public DateTime DataCriacao { get; set; } = DateTime.Now;
>>>>>>> Stashed changes
    }
}