using MarketPlace.DAL;
using MarketPlace.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlace.ModelsValidators {
  public class LoginNotExistsAttribute:ValidationAttribute {

    public string GetErrorMessage() => "User with this login already exists";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
      UserRegisterModel registerModel = (UserRegisterModel)validationContext.ObjectInstance;

      if(_DAL.Users.ByLogin(registerModel.Login) != null)
        return new ValidationResult(GetErrorMessage());

      return ValidationResult.Success;
    }
  }
}