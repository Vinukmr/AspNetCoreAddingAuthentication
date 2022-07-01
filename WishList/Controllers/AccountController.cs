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
                ApplicationUser user = new ApplicationUser();
                user.UserName = vview.Email;
                user.Email = vview.Email;
                var result = _userManager.CreateAsync(user, vview.Password);
                if (!result.Result.Succeeded) {
                    foreach (var item in result.Result.Errors)
                    {
                        ModelState.AddModelError(vview.Password,item.Description);
                    }
                    return View(vview);
                }
                return RedirectToAction("Index","Home");
            }
            return View(vview);
        }

        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel modell)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = modell.Email;
                user.Email = modell.Email;
                var result = _signInManager.PasswordSignInAsync(user,modell.Password,false,false);
                if (!result.Result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }


                return RedirectToAction("Index", "Item");
            }
            return View(modell);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
    
}
