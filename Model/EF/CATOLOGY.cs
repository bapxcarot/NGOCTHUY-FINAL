namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATOLOGY")]
    public partial class CATOLOGY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATOLOGY()
        {
            PRODUCTS = new HashSet<PRODUCT>();
        }

        [Key]
        public int ID_CAT { get; set; }

        [StringLength(50)]
        public string NAME_CAT { get; set; }

        [StringLength(255)]
        public string META { get; set; }

        public int? ORDER { get; set; }

        [StringLength(255)]
        public string LINK { get; set; }

        public int? HIDE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
    }
}
