using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MarketPlace.ModelsValidators;

namespace MarketPlace.Models.User {
  public class UserRegisterModel {
    [Required]
    [LoginNotExists]
    [Display(Name = "Login", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string Login { get; set; }


    [Required]
    [RegularExpression(@"[0-9]{11}", ErrorMessageResourceName = "PhoneError", ErrorMessageResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    [PhoneNotExists]
    [Display(Name = "Phone", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string Phone { get; set; }


    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessageResourceName = "PasswordError1", ErrorMessageResourceType = typeof(Resources.Models.Users.ChangePasswordModel))]
    [Display(Name = "Password", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string Password { get; set; }


    [Required]
    [Compare(nameof(Password), ErrorMessageResourceName = "PasswordError2", ErrorMessageResourceType = typeof(Resources.Models.Users.ChangePasswordModel))]
    [Display(Name = "RepeatPassword", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string RepeatPassword { get; set; }
  }
}