using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarketPlace.Filters {
  public class CustomAuthAttribute:FilterAttribute, IAuthenticationFilter {
    private string _controller;
    private string _action;

    public CustomAuthAttribute() { }

    public CustomAuthAttribute(string controller, string action) {
      this._controller = controller;
      this._action = action;
    }
    public void OnAuthentication(AuthenticationContext filterContext) {
      var currentUser = filterContext.HttpContext.User;

      if(!currentUser.Identity.IsAuthenticated) {
        var routeDict = new RouteValueDictionary();

        if(string.IsNullOrWhiteSpace(_controller))
          _controller = "Users";
        if(string.IsNullOrWhiteSpace(_action))
          _action = "Login";

        routeDict.Add("controller", _controller);
        routeDict.Add("action", _action);
        filterContext.Result = new RedirectToRouteResult(routeDict);
      }
    }

    public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {
      
    }
  }
}