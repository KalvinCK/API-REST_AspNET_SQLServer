using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_REST.Models
{
    [Table("User")]
    public class User
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Este campo � obrigatorio.")]
        [Display(Name = "* Nome")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "O nome de usuario precisa ter entre 5 e 12 caracteres.")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Este campo � obrigatorio")]
        [Display(Name = "* E-mail")]
        [StringLength(maximumLength: 254)]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "N�o � um endere�o de e-mail v�lido.")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Este campo � obrigatorio")]
        [Display(Name = "* Senha")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 30 caracteres.")]
        [RegularExpression(@"^(?=.*[!@#$%^&*()_+-=\\|{}\[\]:;"",.<>?])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9!@#$%^&*()_+-=\\|{}\[\]:;""<>,.?]{8,}$",
               ErrorMessage = "A senha deve ter ao menos um caractere mai�sculo, caractere especial e um numero.")]
        public string Password { get; set; } = string.Empty;
    }
}