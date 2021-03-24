using MarketPlace.SL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers {
  public class LocalizationController:BaseController {

    public ActionResult ChangeLanguage(string lang) {
      _SL.Users.SetLanguageCookie(lang);
      return Redirect(Request.UrlReferrer.ToString());
    }

  }
}