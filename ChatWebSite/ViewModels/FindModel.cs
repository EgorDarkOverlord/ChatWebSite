using ChatWebSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebSite.ViewModels
{
    public class FindModel
    {
        [Required (ErrorMessage ="Не указано название или логин")]
        public string SearchString { get; set; }

        [Required(ErrorMessage = "Там же выбор, ты как это поле пустым оставил")]
        public string SearchByType { get; set; }

        [Required(ErrorMessage = "Там же выбор, ты как это поле пустым оставил")]
        public string SearchByAttribute { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Chat> Chats { get; set; }

        public FindModel()
        {
            Chats = new List<Chat>();
            Users = new List<User>();
        }
    }
}
