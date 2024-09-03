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
        public string? Titulo { get; set; }

        [Display(Name = "Categoria")]
        public Categorias Categoria { get; set; }
    }
}