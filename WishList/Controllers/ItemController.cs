using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WishList.Models;

namespace WishList.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context, UserManager<ApplicationUser> usr)
        {
            _context = context;
            _userManager = usr;
        }

        public IActionResult Index()
        {
            var uu = _userManager.GetUserAsync(HttpContext.User).Result;
            var model = _context.Items.Where(e => e.User.Id == uu.Id).ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Models.Item item)
        {
            var usr = _userManager.GetUserAsync(HttpContext.User);
            item.Id = usr.Id;
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var x = _userManager.GetUserAsync(HttpContext.User).Result;
            var item = _context.Items.FirstOrDefault(e => e.Id == id);
            if (item.User.Id != x.Id)
                return Unauthorized();
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
