using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Geef een naam aan.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Geef een email aan."), DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Geef een wachtwoord aan."), DataType(DataType.Password)]
        public string Password { get; set; }
        public int Role { get; set; }
    }
}