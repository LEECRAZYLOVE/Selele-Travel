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
    
    public partial class quote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public quote()
        {
            //this.cabservices = new HashSet<cabservice>();
            //this.orders = new HashSet<order>();
        }
    
        public string quote_no { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string service { get; set; }
        public string timequoted { get; set; }
        public Nullable<System.DateTime> datequoted { get; set; }
        public string consultant_no { get; set; }
        public string agencyphonenumber { get; set; }
        public string agencyname { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cabservice> cabservices { get; set; }
        public virtual conference conference { get; set; }
        public virtual flight flight { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
        public virtual staff staff { get; set; }
    }
}
