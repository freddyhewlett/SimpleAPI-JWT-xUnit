using System;
using System.ComponentModel.DataAnnotations;

namespace APIDomain.DTOs.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "{0} deve conter no máximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        [StringLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
