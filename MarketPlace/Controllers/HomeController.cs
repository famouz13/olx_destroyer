using MarketPlace.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers {


  public class HomeController:BaseController {


    [SubstituteLanguageInRoute]
    public ActionResult Index() {
      return View();
    }
  }
}