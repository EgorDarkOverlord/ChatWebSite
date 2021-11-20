using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebSite.Models;

namespace ChatWebSite.ViewModels
{
    public class InviteToChatModel
    {
        public User Guest { get; set; }

        public string GuestId { get; set; }

        public IEnumerable<Chat> Chats { get; set; }

        public int ChatId { get; set; }
    }
}
