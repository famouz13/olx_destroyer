using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarketPlace.Filters {
  public class SubstituteLanguageInRouteAttribute:FilterAttribute, IActionFilter {
    public void OnActionExecuted(ActionExecutedContext filterContext) {
      var routeData = filterContext.RouteData;
      string lang = routeData.Values["lang"]?.ToString();

      var langCookie = filterContext.HttpContext.Request.Cookies["lang"];

      string langFromCookie = langCookie is null ? ConfigurationManager.AppSettings["DefaultLanguage"] : langCookie.Value;

      if(langFromCookie.CompareTo(lang) != 0) {
        RouteValueDictionary routeValues = new RouteValueDictionary();

        routeData.Values.Keys.ToList().ForEach(k => {
          routeValues.Add(k, routeData.Values[k]);
        });

        if(routeValues.ContainsKey("lang"))
          routeValues.Remove("lang");

        routeValues.Add("lang", langFromCookie);
        filterContext.Result = new RedirectToRouteResult(routeValues);
      }
    }

    public void OnActionExecuting(ActionExecutingContext filterContext) {

    }
  }
}