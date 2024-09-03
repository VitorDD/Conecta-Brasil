using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CONECTA_BRASIL.Models
{
    public class Pessoa : Usuario
    {
        public enum Interesses
        {
            Noticias,
            Esportes,
            Eventos,
            Avisos
        }

        [Required(ErrorMessage = "Data requerida.")]
        [Display(Name = "Data")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Interesses")]
        public Interesses Interesse { get; set; }
    }
}