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
    
    public partial class SPONSORSHIP
    {
        public int ID { get; set; }
        public Nullable<int> AMOUNT { get; set; }
        public Nullable<int> EVEN { get; set; }
        public string NAME { get; set; }
        public string SPONSORSHIP_DATE { get; set; }
        public Nullable<int> CANDIDATE_ID { get; set; }
        public Nullable<int> DONATION_TYPE_ID { get; set; }
    
        public virtual CANDIDATE CANDIDATE { get; set; }
        public virtual DONATION_TYPE DONATION_TYPE { get; set; }
        public virtual EVEN EVEN1 { get; set; }
    }
}