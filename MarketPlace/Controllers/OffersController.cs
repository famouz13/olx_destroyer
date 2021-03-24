using MarketPlace.DAL;
using MarketPlace.Filters;
using MarketPlace.Models.AuthModels;
using MarketPlace.Models.Offer;
using MarketPlace.SL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers {
  public class OffersController:BaseController {
    // GET: Offers

    [CustomAuth]
    [SubstituteLanguageInRoute]
    public ViewResult CreateOffer() {
      var createOfferModel = new OfferCreateModel();
      createOfferModel.Categories = _DAL.Categories.All();
      return View(createOfferModel);
    }


    [HttpPost]
    [CustomAuth]
    [SubstituteLanguageInRoute]
    public ActionResult CreateOffer(OfferCreateModel createModel) {

      if(ModelState.IsValid) {
        var currentUser = base.User;

        createModel.Date = DateTime.Now;
        createModel.fk_UserID = currentUser.UserID;

        var uploadedOffer = _DAL.Offers.Add(createModel);

        if(Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
          _SL.Images.UploadImages(uploadedOffer, Request.Files, Path.Combine(Server.MapPath("~"), ConfigurationManager.AppSettings["ImagesFolder"]));

        return RedirectToAction("Index", "Users");
      }


      createModel.Categories = _DAL.Categories.All();
      return View(createModel);
    }

    [ChildActionOnly]
    public PartialViewResult GetCategories() {
      return PartialView("CategoriesList", _DAL.Categories.All());
    }

    [SubstituteLanguageInRoute]
    public ViewResult Details(int id) {
      var offerInfo = _DAL.Offers.OfferInfoByOfferID(id);
      var displayModel = _SL.Offers.GetSingleDisplayModel(offerInfo);
      return View("OfferDetails", displayModel);
    }

    public JsonResult AddInFavorites(int id) {
      var currentUserID = base.User.UserID;
      var favItem = _DAL.Offers.AddInFavorites(currentUserID, id);
      return Json(favItem);
    }
  }
}