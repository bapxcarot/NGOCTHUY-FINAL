namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_DETAIL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_CART { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PRO { get; set; }

        public int? SOLD_NUM { get; set; }

        public decimal? PRICE { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
