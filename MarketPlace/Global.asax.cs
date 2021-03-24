using MarketPlace.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MarketPlace {
  public class MvcApplication:System.Web.HttpApplication {
    protected void Application_Start() {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    protected void Application_PostAuthenticateRequest(object sender, EventArgs e) {
      HttpCookie loginCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

      if(loginCookie != null) {
        FormsAuthenticationTicket decryptedTicket = FormsAuthentication.Decrypt(loginCookie.Value);
        UserSerializationModel userSerializtionModel = new JavaScriptSerializer().Deserialize<UserSerializationModel>(decryptedTicket.UserData);

        CustomPrincipal currentUser = new CustomPrincipal(decryptedTicket.Name);
        currentUser.UserID = userSerializtionModel.UserID;

        HttpContext.Current.User = currentUser;
      }


    }
  }
}
