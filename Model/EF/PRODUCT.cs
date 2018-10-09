namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTS")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }

        [Key]
        public int ID_PRO { get; set; }

        [StringLength(50)]
        public string NAME_PRO { get; set; }

        public int? NUMS { get; set; }

        public decimal? PRICE { get; set; }

        [Column(TypeName = "ntext")]
        public string DETAIL { get; set; }

        [StringLength(255)]
        public string IMG1 { get; set; }

        [StringLength(255)]
        public string IMG2 { get; set; }

        [StringLength(255)]
        public string IMG3 { get; set; }

        [StringLength(255)]
        public string META { get; set; }

        public int? ORDER { get; set; }

        [StringLength(255)]
        public string LINK { get; set; }

        public int? HIDE { get; set; }

        public int? ID_CAT { get; set; }

        public virtual CATOLOGY CATOLOGY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}
