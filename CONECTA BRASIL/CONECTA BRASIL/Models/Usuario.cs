using System.ComponentModel.DataAnnotations;

namespace CONECTA_BRASIL.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email requerido.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefone requerido.")]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Senha requerido.")]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }
    }
}