using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebSite.ViewModels
{
    public class CreateRoomModel
    {
        [Required(ErrorMessage = "Не указано название чата")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Не указан логин")]
        [RegularExpression(@"^@\w+$", ErrorMessage = "Некорректный логин")]
        public string Login { get; set; }
        public bool IsPrivate { get; set; }
    }
}
