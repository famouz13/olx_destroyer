using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models.User {
  public class UserLoginModel {
    [Required]
    [Display(Name = "Login", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string Login { get; set; }
    [Required]
    [Display(Name = "Password", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string Password { get; set; }

  }
}