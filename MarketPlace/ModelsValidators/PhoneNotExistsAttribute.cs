using MarketPlace.DAL;
using MarketPlace.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlace.ModelsValidators {
  public class PhoneNotExistsAttribute:ValidationAttribute {

    public string GetErrorMessage() => "This phone number is already taken";
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
      var registerModel = (UserRegisterModel)validationContext.ObjectInstance;

      if(_DAL.Users.ByPhone(registerModel.Phone) != null)
        return new ValidationResult(GetErrorMessage());

      return ValidationResult.Success;
    }
  }
}