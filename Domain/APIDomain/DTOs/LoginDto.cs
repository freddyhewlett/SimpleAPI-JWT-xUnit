using System;
using System.ComponentModel.DataAnnotations;

namespace APIDomain.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        [StringLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Login")]
        public string Email { get; set; }
    }
}
