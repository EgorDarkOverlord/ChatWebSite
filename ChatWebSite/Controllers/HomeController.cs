using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ChatWebSite.Models;
using ChatWebSite.ViewModels;

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
        public async Task<IActionResult> CreateRoom(CreateRoomModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var uniqueLogin = !db.Chats.Any(c => c.Login == model.Login);

            if (uniqueLogin)
            {
                await db.CreateRoomAsync(model, GetUserId());
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("UniqueLoginError", "Логин должен быть уникальным");
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View();
        }

        //Вход на страницу поиска
        public IActionResult Find()
        {
            return View(new FindModel());
        }
        
        //Отображение результатов поиска поиска
        [ActionName("GetFindResult")]
        public async Task<IActionResult> Find(FindModel model)
        {
            if(ModelState.IsValid)
            {
                model = await db.FindModel(model);
            }
            
            return View("Find", model);
        }

        public IActionResult Chat(int id)
        {
            var chat = db.FindChatById(id);

            return View(chat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int chatId, string content)
        {
            await db.CreateMessageAsync(chatId, content, GetUserId());

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
