using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;
using WebSecurity.Models;
using System.Linq;

namespace WebSecurity.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IGiftRepository _giftRepository;

        public HomeController(UserManager<AppUser> userManager, IGiftRepository giftRepository)
        {
            _userManager = userManager;
            _giftRepository = giftRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(string search)
        {
            var users = from u in _userManager.Users select u;
            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(u => u.UserName.Contains(search));
                
                return View(users);
            }
            return View(_userManager.Users);
        }

        [Authorize]
        public async Task<IActionResult> MyWishlist()
        {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            var gifts = _giftRepository.UserGifts(user);
            return View(gifts);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddGift()
        {
            Gift gift = new Gift();
            return View(gift);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddGift(Gift gift)
        {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                gift.IsWish = true;
                gift.UserID = user.Id;
                gift.AppUser = user;
                _giftRepository.AddGift(gift);

            } else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return RedirectToAction("MyWishlist", "Home");
        }

        [HttpPost]
        public IActionResult DeleteGift(int id)
        {
            Gift gift = _giftRepository.Gifts.First(g => g.GiftId == id);
            if (gift != null)
            {
                _giftRepository.DeleteGift(gift);
            } else
            {
                ModelState.AddModelError("", "Error finding gift");
            }
            return RedirectToAction("MyWishlist");
        }
                


    }
}
