using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MarketPlace.Models.DB;

namespace MarketPlace.Models.Offer {
  public class OfferCreateModel {

    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    [Display(Name ="Title", ResourceType = typeof(MarketPlace.Resources.Models.Offers.OfferCreateModel))]
    public string Title { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(200)]
    [Display(Name = "Description", ResourceType = typeof(MarketPlace.Resources.Models.Offers.OfferCreateModel))]
    public string Description { get; set; }

    [Required]
    [Display(Name = "Price", ResourceType = typeof(MarketPlace.Resources.Models.Offers.OfferCreateModel))]
    public decimal Price { get; set; }

    public DateTime Date { get; set; }


    public int fk_UserID { get; set; }

    [Required]
    [Display(Name = "fk_CategoryID", ResourceType = typeof(MarketPlace.Resources.Models.Offers.OfferCreateModel))]
    public int fk_CategoryID { get; set; }

    public List<Categories> Categories { get; set; }

  }
}