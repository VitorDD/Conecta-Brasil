
using System.ComponentModel.DataAnnotations;

namespace CONECTA_BRASIL.Models
{
    public class Instituicao : Usuario
    {
        [Required(ErrorMessage = "Área requerido.")]
        [Display(Name = "Área de atuação")]
        public string? Atuacao { get; set; }

        [Required(ErrorMessage = "CNPJ requerido.")]
        [Display(Name = "CNPJ")]
        public string? CNPJ { get; set; }
    }
}
