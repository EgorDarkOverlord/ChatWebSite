using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
