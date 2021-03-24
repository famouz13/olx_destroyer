using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MarketPlace.ModelsValidators;

namespace MarketPlace.Models.User {
  public class UserUpdateModel {
    public int UserID { get; set; }
    [Display(Name = "Login", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string Login { get; set; }

    [Display(Name = "Phone", ResourceType = typeof(Resources.Models.Users.UserRegisterModel))]
    public string Phone { get; set; }

  }
}