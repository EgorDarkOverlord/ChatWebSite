using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatWebSite.Models
{
    public class ChatDbContext : IdentityDbContext<User>
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }


        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Здесь создается первичный ключ из двух ссылок
            builder.Entity<ChatUser>()
                .HasKey(x => new { x.ChatId, x.UserId });
        }

        public IEnumerable<Chat> FindChatsByUserId(string userId)
        {
            return Chats.Where(x => x.Users.Any(y => y.UserId == userId));
        }

        public Chat FindChatById(int id)
        {
            var chat = Chats
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.Id == id);

            chat.Messages = Messages
                .Where(m => m.ChatId == id)
                .Include(m => m.User)
                .ToList();

            return chat;
        }

        public async Task<Message> CreateMessage(int chatId, string content, string userId)
        {
            var Message = new Message
            {
                Content = content,
                Timestamp = DateTime.Now,
                UserId = userId,
                User = Users.Find(userId),
                ChatId = chatId,
            };

            Messages.Add(Message);
            await SaveChangesAsync();

            return Message;
        }

        public async Task CreateRoom(string name, string userId)
        {
            var chat = new Chat
            {
                Name = name,
                Type = ChatType.Public
            };

            chat.Users.Add(new ChatUser
            {
                UserId = userId,
                Role = UserRole.Owner
            });

            Chats.Add(chat);

            await SaveChangesAsync();
        }
    }
}
