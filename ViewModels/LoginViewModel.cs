using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="Имейл")]
        [Required(ErrorMessage = "Имейл адрес е задължителен")]
        public string Email { get; set; }
        [Display(Name = "Парола")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
