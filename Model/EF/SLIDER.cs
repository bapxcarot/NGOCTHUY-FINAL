namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDER")]
    public partial class SLIDER
    {
        [Key]
        public int ID_SLIDE { get; set; }

        [StringLength(50)]
        public string TITLE { get; set; }

        [StringLength(255)]
        public string IMG { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DATEBEGIN { get; set; }

        [StringLength(255)]
        public string META { get; set; }

        public int? ORDER { get; set; }

        [StringLength(255)]
        public string LINK { get; set; }

        public int? HIDE { get; set; }
    }
}
