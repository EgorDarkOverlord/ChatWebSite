using Microsoft.AspNetCore.Identity;

namespace ChatWebSite.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
    }
}
