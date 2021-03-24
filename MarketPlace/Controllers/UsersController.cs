using MarketPlace.DAL;
using MarketPlace.Filters;
using MarketPlace.Models.AuthModels;
using MarketPlace.Models.User;
using MarketPlace.SL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MarketPlace.Controllers {
  public class UsersController:BaseController {
    // GET: Users

    [CustomAuth]
    [SubstituteLanguageInRoute]
    public ActionResult Index() {
      var currentPrincipal = base.User;
      var currentUser = _DAL.Users.ByID(currentPrincipal.UserID);

      return View(new UserUpdateModel { UserID = currentUser.UserID, Login = currentUser.Login, Phone = currentUser.Phone });
    }


    public RedirectToRouteResult Logout() {
      FormsAuthentication.SignOut();
      return RedirectToAction("Login");
    }

    [SubstituteLanguageInRoute]
    public ViewResult Login() {
      return View();
    }

    [HttpPost]
    [SubstituteLanguageInRoute]
    public ActionResult Login(UserLoginModel loginModel) {
      if(ModelState.IsValid) {
        var user = _DAL.Users.ByLogin(loginModel.Login);

        if(user == null)
          ViewBag.Error = "Password or login inccorect";
        else if(user.Password != loginModel.Password)
          ViewBag.Error = "Password or login inccorect";
        else {
          _SL.Users.SetLoginCookie(user);
          return RedirectToAction("Index");
        }

      }
      return View();
    }

    [SubstituteLanguageInRoute]
    public ViewResult Register() {
      return View();
    }

    [HttpPost]
    [SubstituteLanguageInRoute]
    public ActionResult Register(UserRegisterModel registerModel) {
      if(ModelState.IsValid) {
        var currentUser = _DAL.Users.Add(registerModel);

        _SL.Users.SetLoginCookie(currentUser);

        return RedirectToAction("Index");
      }

      return View(registerModel);
    }

    [CustomAuth]
    [SubstituteLanguageInRoute]
    public ViewResult ChangePassword() {
      return View(new UserChangePasswordModel() { UserID = base.User.UserID });
    }

    [HttpPost]
    [CustomAuth]
    [SubstituteLanguageInRoute]
    public ActionResult ChangePassword(UserChangePasswordModel passwordModel) {
      if(ModelState.IsValid) {
        _DAL.Users.UpdatePassword(passwordModel);
        return RedirectToAction("Index");
      }

      return View();
    }

  }
}