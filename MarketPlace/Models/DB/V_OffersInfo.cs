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
    
    public partial class V_OffersInfo
    {
        public int OfferID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int fk_UserID { get; set; }
        public int fk_CategoryID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Login { get; set; }
        public int UserID { get; set; }
        public string Phone { get; set; }
    }
}