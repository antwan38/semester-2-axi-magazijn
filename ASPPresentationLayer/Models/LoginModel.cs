using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vul een gebruikersnaam in."), DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Vul een wachtwoord in."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}