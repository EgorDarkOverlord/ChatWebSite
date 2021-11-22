using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatWebSite
{
    public class ChatHub : Hub
    {
        public Task JoinRoom(string chatId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public Task LeaveRoom(string chatId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }
    }
}
