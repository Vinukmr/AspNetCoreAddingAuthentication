using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;

namespace WishList.Controllers
{
    public class AccountController : Controller
    {
      public Authorize authorize {get; set;}
      private readonly UserManager<ApplicationUser> _userManager;
      private readonly SignInManager<ApplicationUser> _signInManager;
      
      public AccountController(UserManager<ApplicationUser> usr,SignInManager<ApplicationUser> signin){
        _userManager= usr;
        _signInManager= signin;
      }
    }
    
}
