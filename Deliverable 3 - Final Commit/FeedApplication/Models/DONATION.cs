//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FeedApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONATION
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DATES { get; set; }
        public Nullable<int> DONOR_ID { get; set; }
        public Nullable<int> EVEN { get; set; }
        public Nullable<int> DONATION_TYPE_ID { get; set; }
        public Nullable<int> AMOUNT { get; set; }
    
        public virtual DONATION_TYPE DONATION_TYPE { get; set; }
        public virtual DONOR DONOR { get; set; }
        public virtual EVEN EVEN1 { get; set; }
    }
}
