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
    
    public partial class VOLUNTEER
    {
        public int EMPLOYEE { get; set; }
        public Nullable<int> EMPLOYEE_TYPE_ID { get; set; }
        public Nullable<int> TITLE_ID { get; set; }
        public string NAMED { get; set; }
        public string SURNAME { get; set; }
        public string IDENTITY_NUMBER { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public Nullable<System.DateTime> STARTING { get; set; }
        public Nullable<System.DateTime> ENDING { get; set; }
    
        public virtual TITLE TITLE { get; set; }
    }
}
