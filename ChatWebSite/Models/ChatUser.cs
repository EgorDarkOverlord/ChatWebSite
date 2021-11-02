using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebSite.Models
{
    /// <summary>
    /// Пользователь чата.
    /// Имеет ссылку на пользователя приложения,
    /// ссылку на чат, и свою роль
    /// </summary>
    public class ChatUser
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public UserRole Role { get; set; }
    }
}
