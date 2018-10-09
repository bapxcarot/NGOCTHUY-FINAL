namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MENU")]
    public partial class MENU
    {
        [Key]
        public int ID_MENU { get; set; }

        [StringLength(50)]
        public string TITLE { get; set; }

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
