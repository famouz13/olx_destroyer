using MarketPlace.DAL;
using MarketPlace.Filters;
using MarketPlace.Models.Offer;
using MarketPlace.SL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers {
  public class SearchController:BaseController {
    // GET: Search
    [SubstituteLanguageInRoute]
    public ActionResult Index() {
      return View();
    }


    public PartialViewResult SearchOffers(DateTime? dateFrom, DateTime? dateTo, int? priceFrom, int? priceTo, string title, int categoryID) {
      List<OfferDisplayModel> offerDisplayModels = _SL.Offers.SearchOffers(dateFrom, dateTo, priceFrom, priceTo, title, categoryID);
      return PartialView("SearchOffersResults", offerDisplayModels);
    }

    public PartialViewResult UserOffers() {
      List<OfferDisplayModel> offerDisplayModels = _SL.Offers.SearchByUserID(base.User.UserID);
      return PartialView("SearchOffersResults", offerDisplayModels);
    }

    public PartialViewResult UserFavoriteOffers() {
      List<OfferDisplayModel> offerDisplayModels = _SL.Offers.SearchFavoritesByUserID(base.User.UserID);
      return PartialView("SearchOffersResults", offerDisplayModels);
    }
  }
}