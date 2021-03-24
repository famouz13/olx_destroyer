using MarketPlace.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace MarketPlace.Controllers {
  public class BaseController:Controller {
    protected virtual new CustomPrincipal User { get => HttpContext.User as CustomPrincipal; }

    protected override void OnActionExecuted(ActionExecutedContext filterContext) {
      base.OnActionExecuted(filterContext);

      var langCookie = HttpContext.Request.Cookies["lang"];

      string lang = langCookie is null ? ConfigurationManager.AppSettings["DefaultLanguage"] : langCookie.Value;
      CultureInfo targetCulture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentUICulture = targetCulture;
    }


  }
}