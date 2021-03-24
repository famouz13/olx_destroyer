using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MarketPlace.Models.AuthModels {
  public class CustomPrincipal:ICustomPrincipal {
    public int UserID { get; set; }

    public IIdentity Identity { get; private set; }

    public bool IsInRole(string role) => false;

    public CustomPrincipal(string username) {
      Identity = new GenericIdentity(username);
    }

  }
}