using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using Microsoft.AspNetCore.Identity;
using WishList.Models.AccountViewModels;
namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {      
      private readonly UserManager<ApplicationUser> _userManager;
      private readonly SignInManager<ApplicationUser> _signInManager;
      
      public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager){
        _userManager= userManager;
        _signInManager= signInManager;
      }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel vview)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index","Home");
            }
            return View(vview);
        }

    }
    
}
