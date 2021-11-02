using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebSite.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указана эл. почта")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
