using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MarketPlace.ModelsValidators;

namespace MarketPlace.Models.User {
  public class UserChangePasswordModel {
    [Required]
    public int UserID { get; set; }

    [Required]
    [OldPasswordCorrect]
    [Display(Name = "OldPassword", ResourceType = typeof(Resources.Models.Users.ChangePasswordModel))]
    public string OldPassword { get; set; }


    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessageResourceName = "PasswordError1", ErrorMessageResourceType = typeof(Resources.Models.Users.ChangePasswordModel))]
    [Display(Name = "NewPassword", ResourceType = typeof(Resources.Models.Users.ChangePasswordModel))]
    public string NewPassword { get; set; }

    [Required]
    [Compare(nameof(NewPassword), ErrorMessageResourceName = "PasswordError2", ErrorMessageResourceType = typeof(Resources.Models.Users.ChangePasswordModel))]
    [Display(Name = "NewRepeatPassword", ResourceType = typeof(Resources.Models.Users.ChangePasswordModel))]
    public string NewRepeatPassword { get; set; }
  }
}