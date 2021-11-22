using System.ComponentModel.DataAnnotations;

namespace ChatWebSite.ViewModels
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Не указан пароль")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmNewPassword { get; set; }
    }
}
