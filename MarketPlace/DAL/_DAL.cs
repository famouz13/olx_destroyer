using MarketPlace.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketPlace.Models.DB;
using MarketPlace.Models.Offer;

namespace MarketPlace.DAL {
  public static class _DAL {
    public static class Users {
      public static Models.DB.Users Add(UserRegisterModel registerModel) {
        using(var db = new MarketplaceDBEntities()) {
          var newUser = new Models.DB.Users();

          newUser.Login = registerModel.Login;
          newUser.Password = registerModel.Password;
          newUser.Phone = registerModel.Phone;

          db.Users.Add(newUser);
          db.SaveChanges();

          return newUser;
        }
      }

      public static Models.DB.Users ByID(int userID) {
        using(var db = new MarketplaceDBEntities()) {
          return db.Users.FirstOrDefault(n => n.UserID == userID);
        }
      }

      public static Models.DB.Users ByLogin(string Login) {
        using(var db = new MarketplaceDBEntities()) {
          return db.Users.FirstOrDefault(n => n.Login == Login);
        }
      }

      public static Models.DB.Users ByPhone(string Phone) {
        using(var db = new MarketplaceDBEntities()) {
          return db.Users.FirstOrDefault(n => n.Phone == Phone);
        }
      }

      public static bool UpdatePassword(UserChangePasswordModel model) {
        using(var db = new MarketplaceDBEntities()) {
          var user = db.Users.FirstOrDefault(n => n.UserID == model.UserID);

          if(user == null)
            return false;

          user.Password = model.NewPassword;
          db.SaveChanges();
          return true;
        }
      }
    }


    public static class Offers {
      public static Models.DB.Offers Add(OfferCreateModel createModel) {

        var newOffer = new Models.DB.Offers() {
          fk_UserID = createModel.fk_UserID,
          fk_CategoryID = createModel.fk_CategoryID,
          Title = createModel.Title,
          Description = createModel.Description,
          Date = createModel.Date,
          Price = createModel.Price,
        };

        using(var db = new MarketplaceDBEntities()) {
          db.Offers.Add(newOffer);
          db.SaveChanges();
          return newOffer;
        }

      }

      public static V_OffersInfo OfferInfoByOfferID(int offerID) {
        using(var db = new MarketplaceDBEntities()) {
          return db.V_OffersInfo.FirstOrDefault(n => n.OfferID == offerID);
        }
      }

      public static List<V_OffersInfo> OfferInfoByUserID(int userID) {
        using(var db = new MarketplaceDBEntities()) {
          return db.V_OffersInfo.AsNoTracking().Where(n => n.UserID == userID).ToList();
        }
      }

      public static List<V_OffersInfo> FavoritesOfferInfoByUserID(int userID) {
        using(var db = new MarketplaceDBEntities()) {
          var favorites = db.FavoriteOffersUsers.AsNoTracking().Where(n => n.fk_UserID == userID).Select(n => n.fk_OfferID).ToList();
          return db.V_OffersInfo.AsNoTracking().Where(n => favorites.Contains(n.OfferID)).ToList();
        }
      }

      public static List<V_OffersInfo> OfferInfoAll() {
        using(var db = new MarketplaceDBEntities()) {
          return db.V_OffersInfo.AsNoTracking().ToList();
        }
      }

      public static List<V_OffersInfo> SearchOffers(DateTime? dateFrom, DateTime? dateTo, int? priceFrom, int? priceTo, string title, int categoryID) {
        using(var db = new MarketplaceDBEntities()) {
          var offers = (from oi in db.V_OffersInfo select oi);

          if(dateFrom != null && dateTo != null)
            offers = offers.Where(n => n.Date <= dateTo && n.Date >= dateFrom);

          if(priceFrom != null && priceTo != null)
            offers = offers.Where(n => n.Price >= priceFrom && n.Price <= priceTo);

          if(!string.IsNullOrWhiteSpace(title))
            offers = offers.Where(n => n.Title.Contains(title));

          if(categoryID != 0)
            offers = offers.Where(n => n.fk_CategoryID == categoryID);

          return offers.ToList();
        }
      }


      public static FavoriteOffersUsers AddInFavorites(int UserID, int OfferID) {
        using(var db = new MarketplaceDBEntities()) {
          var inFavoritesItem = db.FavoriteOffersUsers.FirstOrDefault(n => n.fk_OfferID == OfferID && n.fk_UserID == UserID);

          if(inFavoritesItem != null) {
            db.FavoriteOffersUsers.Remove(inFavoritesItem);
            db.SaveChanges();
            inFavoritesItem.FavoriteOfferID = -1;
            return inFavoritesItem;
          }

          var newFavItem = new FavoriteOffersUsers() { fk_OfferID = OfferID, fk_UserID = UserID };
          db.FavoriteOffersUsers.Add(newFavItem);
          db.SaveChanges();
          return newFavItem;
        }
      }

      public static FavoriteOffersUsers FavoriteByUserNOfferID(int userID, int offerID) {
        using(var db = new MarketplaceDBEntities()) {
          return db.FavoriteOffersUsers.AsNoTracking().FirstOrDefault(n => n.fk_UserID == userID && n.fk_OfferID == offerID);
        }
      }
    }

    public static class Categories {
      public static List<Models.DB.Categories> All() {
        using(var db = new MarketplaceDBEntities()) {
          return db.Categories.AsNoTracking().ToList();
        }
      }
    }


    public static class OffersImages {
      public static void AddRange(List<Models.DB.OffersImages> offersImages) {
        using(var db = new MarketplaceDBEntities()) {
          db.OffersImages.AddRange(offersImages);
          db.SaveChanges();
        }
      }

      public static List<string> ByOfferID(int offerID) {
        using(var db = new MarketplaceDBEntities()) {
          return db.OffersImages.AsNoTracking().Where(n => n.fk_OfferID == offerID).Select(n => n.ImagePath).ToList();
        }
      }
    }

  }
}