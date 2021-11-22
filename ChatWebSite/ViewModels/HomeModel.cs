using ChatWebSite.Models;
using System.Collections.Generic;

namespace ChatWebSite.ViewModels
{
    public class HomeModel
    {
        public IEnumerable<Chat> Chats { get; set; }
        public CreateRoomModel CreateChatModel { get; set; }
    }
}
