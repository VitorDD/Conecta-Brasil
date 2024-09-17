
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CONECTA_BRASIL.Models
{
    public class Pessoa : Usuario
    {
        [Required(ErrorMessage = "Data requerida.")]
        [Display(Name = "Data")]
        public DateTime BirthDate { get; set; }
    }
}
