//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webhoconl.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OderDetail
    {
        public Nullable<int> Subject_ID { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Oder_ID { get; set; }
        public Nullable<double> Line_Total { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int Oder_detail_ID { get; set; }
    
        public virtual Oder Oder { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
