using MarketPlace.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Models.Offer {
  public class OfferDisplayModel {
    public V_OffersInfo OffersInfo { get; set; }

    public List<string> ImagesPath { get; set; }

    public FavoriteOffersUsers FavoriteOffers { get; set; }
  }
}