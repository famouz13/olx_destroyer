//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketPlace.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class OffersImages
    {
        public int OfferImageID { get; set; }
        public int fk_OfferID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    
        public virtual Offers Offers { get; set; }
    }
}
