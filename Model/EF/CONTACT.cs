namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACT")]
    public partial class CONTACT
    {
        public int id { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }
    }
}
