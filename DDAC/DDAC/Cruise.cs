//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDAC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cruise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cruise()
        {
            this.PurchaseHistories = new HashSet<PurchaseHistory>();
        }
    
        public int CruiseID { get; set; }
        public int PortID { get; set; }
        public int DestinationID { get; set; }
        public int ShipID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Price { get; set; }
    
        public virtual Destination Destination { get; set; }
        public virtual Port Port { get; set; }
        public virtual Ship Ship { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; }
    }
}