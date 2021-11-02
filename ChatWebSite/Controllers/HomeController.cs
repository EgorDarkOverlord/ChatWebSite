using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ChatWebSite.Models;



namespace ChatWebSite.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ChatDbContext db;

        
        /// <summary>
        /// Находит Id пользователя
        /// </summary>
        private string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier).Value;

        public HomeController(ChatDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var chats = db.FindChatsByUserId(GetUserId()).ToList();
            return View(chats);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            await db.CreateRoom(name, GetUserId());

            return RedirectToAction("Index");
        }

        public IActionResult Chat(int id)
        {
            var chat = db.FindChatById(id);

            return View(chat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int chatId, string content)
        {
            await db.CreateMessage(chatId, content, GetUserId());

            return RedirectToAction("Chat", new { id = chatId });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
