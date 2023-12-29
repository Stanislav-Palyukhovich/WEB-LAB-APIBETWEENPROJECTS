using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;
        public ImageController(UserManager<ApplicationUser>
        userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Avatar != null)
                return File(user.Avatar, "image/...");
            else
            {
                var avatarPath = "/Images/anonymous.png";
                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)

                .CreateReadStream(), "/Images/anonymous.png");

            }
        }
    }
}
