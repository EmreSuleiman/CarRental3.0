using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Имейл адрес ")]
        [Required(ErrorMessage ="Попълнете Имейл")]
        public string? Email { get; set; }
        [Display(Name = "Парола")]
        [Required]
        [DataType(DataType.Password)]
        public string? Password {  get; set; }
        [Display(Name = "Потвърди парола")] 
        [Required(ErrorMessage ="Моля потвърдете паролата")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Паролата не съвпада")]
        public string? ConfirmPassword { get; set; }
        [Display(Name = "Пълно име")]
        [Required(ErrorMessage = "Моля въведете пълното си име")]
        public string? FullName { get; set; }
    }
}
