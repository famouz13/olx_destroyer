using MarketPlace.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Security;
using System.Web.Security;
using MarketPlace.Models.DB;
using System.IO;
using MarketPlace.DAL;
using MarketPlace.Models.Offer;

namespace MarketPlace.SL {
  public static class _SL {
    public static class Users {
      public static void SetLoginCookie(Models.DB.Users user) {
        var userSerializationModel = new UserSerializationModel();
        userSerializationModel.UserID = user.UserID;

        string userJson = new JavaScriptSerializer().Serialize(userSerializationModel);
        int cookieLifeTime = Convert.ToInt32(ConfigurationManager.AppSettings["CookieLifeTime"]);

        DateTime cookieDeathTime = DateTime.Now.AddMinutes(cookieLifeTime);

        FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(
          1, user.Login,
          DateTime.Now, cookieDeathTime,
          true, userJson
          );

        string encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);

        HttpCookie loginCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        loginCookie.Expires = cookieDeathTime;

        HttpContext.Current.Response.SetCookie(loginCookie);
      }

      public static void ExtendCookieLife(FormsAuthenticationTicket ticketToExtend) {
        DateTime cookieDeatTime = DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["CookieLifeTime"]));

        var refreshedTicket = new FormsAuthenticationTicket(1, ticketToExtend.Name, DateTime.Now, cookieDeatTime, true, ticketToExtend.UserData);
        string encryptedTicket = FormsAuthentication.Encrypt(refreshedTicket);

        HttpCookie refreshedCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        refreshedCookie.Expires = cookieDeatTime;

        HttpContext.Current.Response.SetCookie(refreshedCookie);
      }

      public static void SetLanguageCookie(string lang) {
        HttpCookie langCookie = new HttpCookie("lang", lang);
        langCookie.Expires = DateTime.MaxValue;
        HttpContext.Current.Response.SetCookie(langCookie);
      }

    }


    public static class Images {
      public static void UploadImages(MarketPlace.Models.DB.Offers offer, HttpFileCollectionBase files, string filesFolder) {
        string offerImgsDirPath = Path.Combine(filesFolder, offer.OfferID.ToString());

        if(!Directory.Exists(offerImgsDirPath))
          Directory.CreateDirectory(offerImgsDirPath);

        var imagesToSave = new List<OffersImages>();

        for(int i = 0; i < files.Count; i++) {
          HttpPostedFileBase file = files[i];

          var newImg = new OffersImages();
          newImg.fk_OfferID = offer.OfferID;
          newImg.ImageName = DateTime.Now.Ticks.ToString();

          var dir = ConfigurationManager.AppSettings["ImagesFolder"];
          newImg.ImagePath = Path.Combine(dir, offer.OfferID.ToString(), newImg.ImageName + Path.GetExtension(file.FileName));

          string fullImagePath = Path.Combine(offerImgsDirPath, newImg.ImageName + Path.GetExtension(file.FileName));
          imagesToSave.Add(newImg);
          file.SaveAs(fullImagePath);
        }
        _DAL.OffersImages.AddRange(imagesToSave);
      }
    }

    public static class Offers {
      public static List<OfferDisplayModel> GetDisplayModels(ref List<V_OffersInfo> v_OffersInfos) {
        var displayModels = new List<OfferDisplayModel>();

        v_OffersInfos.ForEach(n => {
          displayModels.Add(new OfferDisplayModel {
            OffersInfo = n,
            ImagesPath = _DAL.OffersImages.ByOfferID(n.OfferID),
            FavoriteOffers = _DAL.Offers.FavoriteByUserNOfferID(n.fk_UserID, n.OfferID)
          });
        });

        return displayModels;
      }

      public static OfferDisplayModel GetSingleDisplayModel(V_OffersInfo v_OffersInfo) {
        var displayModel = new OfferDisplayModel();
        displayModel.OffersInfo = v_OffersInfo;
        displayModel.ImagesPath = _DAL.OffersImages.ByOfferID(v_OffersInfo.OfferID);
        return displayModel;
      }

      public static List<OfferDisplayModel> SearchOffers(DateTime? dateFrom, DateTime? dateTo, int? priceFrom, int? priceTo, string title, int categoryID) {
        var items = _DAL.Offers.SearchOffers(dateFrom, dateTo, priceFrom, priceTo, title, categoryID);
        return GetDisplayModels(ref items);
      }

      public static List<OfferDisplayModel> SearchByUserID(int UserID) {
        var items = _DAL.Offers.OfferInfoByUserID(UserID);
        return GetDisplayModels(ref items);
      }

      //todo
      public static List<OfferDisplayModel> SearchFavoritesByUserID(int UserID) {
        var items = _DAL.Offers.FavoritesOfferInfoByUserID(UserID);
        return GetDisplayModels(ref items);
      }
    }
  }


}