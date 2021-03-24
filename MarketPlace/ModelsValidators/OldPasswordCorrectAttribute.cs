using MarketPlace.DAL;
using MarketPlace.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MarketPlace.ModelsValidators {
  public class OldPasswordCorrectAttribute:ValidationAttribute {

    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
      var model = (UserChangePasswordModel)validationContext.ObjectInstance;

      var user = _DAL.Users.ByID(model.UserID);

      if(user.Password != model.OldPassword)
        return new ValidationResult("Incorrect old password");

      return ValidationResult.Success;
    }
  }
}