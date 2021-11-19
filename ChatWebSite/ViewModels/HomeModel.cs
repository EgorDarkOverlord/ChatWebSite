using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebSite.Models;

namespace ChatWebSite.ViewModels
{
    public class HomeModel
    {
        public IEnumerable<Chat> Chats { get; set; }
        public CreateRoomModel CreateChatModel { get; set; }
    }
}
