//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAYCANHNT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.CART_DETAIL = new HashSet<CART_DETAIL>();
        }
    
        public int ID_PRO { get; set; }
        public string NAME_PRO { get; set; }
        public Nullable<int> NUMS { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public string DETAIL { get; set; }
        public string IMG1 { get; set; }
        public string IMG2 { get; set; }
        public string IMG3 { get; set; }
        public string META { get; set; }
        public Nullable<int> ORDER { get; set; }
        public string LINK { get; set; }
        public Nullable<int> HIDE { get; set; }
        public Nullable<int> ID_CAT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART_DETAIL> CART_DETAIL { get; set; }
        public virtual CATOLOGY CATOLOGY { get; set; }
    }
}
