//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeleleTravel
{
    using System;
    using System.Collections.Generic;
    
    public partial class flight
    {
        public string quote_no { get; set; }
        public string order_no { get; set; }
        public string airline { get; set; }
        public string fromcity { get; set; }
        public string tocity { get; set; }
        public Nullable<System.DateTime> departdate { get; set; }
        public Nullable<System.DateTime> arrivedate { get; set; }
        public Nullable<int> numberofbags { get; set; }
        public Nullable<double> totalamount { get; set; }
        public string flightspecs { get; set; }
        public Nullable<int> numberofpassengers { get; set; }
    }
}
