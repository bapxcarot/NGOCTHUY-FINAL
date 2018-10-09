namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BLOG")]
    public partial class BLOG
    {
        [Key]
        public int ID_BLOG { get; set; }

        [StringLength(50)]
        public string TITLE { get; set; }

        [StringLength(255)]
        public string IMG { get; set; }

        [Column(TypeName = "ntext")]
        public string DETAIL { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DATEBEGIN { get; set; }

        [StringLength(255)]
        public string META { get; set; }

        public int? ORDER { get; set; }

        [StringLength(255)]
        public string LINK { get; set; }

        public int? HIDE { get; set; }

        public int? ID_USERS { get; set; }

        [Column(TypeName = "ntext")]
        public string DESCRIPTION { get; set; }

        public virtual USER USER { get; set; }
    }
}
