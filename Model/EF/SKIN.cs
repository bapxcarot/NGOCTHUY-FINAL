namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SKIN")]
    public partial class SKIN
    {
        public int id { get; set; }

        public string logo { get; set; }

        public string comercial { get; set; }

        public string comercial_link { get; set; }

        public string googlemap { get; set; }

        public string fanpage { get; set; }

        [Column(TypeName = "ntext")]
        public string footer { get; set; }

        public string youtube { get; set; }

        [Column(TypeName = "ntext")]
        public string aboutus { get; set; }

        [Column(TypeName = "ntext")]
        public string shopinfo { get; set; }

        [Column(TypeName = "ntext")]
        public string deliveryinfo { get; set; }
    }
}
