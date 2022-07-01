using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotation;

namespace WishList.Models
{
    public class RegisterViewModel
    {
      [Required]
      [EmailAddress]
      public string Email {get; set;}
      [Required]
      [DataType.Password]
      [StringLength=100]
      [MinimumLength=8]
      public string Password {get; set;}
      [Required]
      [DataType.Password]
      [Compare="Password"]
      public string ConfirmPassword {get; set;}
    }
}
