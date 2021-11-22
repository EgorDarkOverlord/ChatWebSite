using ChatWebSite.Models;
using System.Collections.Generic;

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
