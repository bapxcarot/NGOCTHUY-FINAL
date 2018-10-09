namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            BLOGs = new HashSet<BLOG>();
            ORDERs = new HashSet<ORDER>();
        }

        [Key]
        public int ID_USERS { get; set; }

        [StringLength(30)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public string ADDRESS { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        public int? PERMISSION { get; set; }

        [StringLength(50)]
        public string META { get; set; }

        public int? ORDER { get; set; }

        [StringLength(255)]
        public string LINK { get; set; }

        public int? HIDE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BLOG> BLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERs { get; set; }
    }
}
