using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using Microsoft.AspNetCore.Identity;

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
        public ViewResult Register() {
            return View();
        }
    }
    
}
