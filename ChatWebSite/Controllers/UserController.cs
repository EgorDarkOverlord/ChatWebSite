using ChatWebSite.Models;
using ChatWebSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatWebSite.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserManager<User> _userManager;

        string _userId;

        /// <summary>
        /// Находит Id пользователя
        /// </summary>
        private string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier).Value;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _userId = GetUserId();
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Edit()
        {
            User user = await _userManager.FindByIdAsync(_userId);

            if (user == null)
            {
                return NotFound();
            }

            EditUserModel model = new EditUserModel
            {
                Email = user.Email,
                Name = user.UserName,
                Login = user.Login
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(_userId);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Name;
                    user.Login = model.Login;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(_userId);

                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as
                        IPasswordValidator<User>;

                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as
                        IPasswordHasher<User>;

                    var result =
                        await _passwordValidator.ValidateAsync(
                            _userManager, user, model.NewPassword);

                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View(model);
        }

        [ActionName("Delete")]
        [HttpGet]
        public IActionResult ConfirmDelete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            User user = await _userManager.FindByIdAsync(_userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Logout", "Account");
        }
    }
}
