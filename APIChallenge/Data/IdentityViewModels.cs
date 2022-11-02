using System.ComponentModel.DataAnnotations;

namespace APIChallenge.Data
{
    public class RegiterUserViewModels
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [EmailAddress(ErrorMessage = "o campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "o campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="as senhas não conferam")]
        public string confirmPassword { get; set; }
    }


    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="O Campo {0} e obrigatório")]
        [EmailAddress(ErrorMessage = "o campo {0} está em formato inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "o campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Password { get; set; }

    }
}
