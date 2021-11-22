using System.ComponentModel.DataAnnotations;

namespace ChatWebSite.ViewModels
{
    public class EditUserModel
    {
        [Required(ErrorMessage = "Не указана эл. почта")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [RegularExpression(@"^@\w+$", ErrorMessage = "Некорректный логин")]
        public string Login { get; set; }
    }
}
