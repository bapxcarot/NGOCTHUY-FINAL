namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CAYCANHNT : DbContext
    {
        public CAYCANHNT()
            : base("name=CAYCANHNT")
        {
        }

        public virtual DbSet<BLOG> BLOGs { get; set; }
        public virtual DbSet<CATOLOGY> CATOLOGies { get; set; }
        public virtual DbSet<CONTACT> CONTACTs { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDER_DETAIL> ORDER_DETAIL { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<SKIN> SKINs { get; set; }
        public virtual DbSet<SLIDER> SLIDERs { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BLOG>()
                .Property(e => e.IMG)
                .IsUnicode(false);

            modelBuilder.Entity<BLOG>()
                .Property(e => e.META)
                .IsUnicode(false);

            modelBuilder.Entity<CATOLOGY>()
                .Property(e => e.META)
                .IsUnicode(false);

            modelBuilder.Entity<MENU>()
                .Property(e => e.META)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.META)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.ORDER_DETAIL)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER_DETAIL>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.IMG1)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.IMG2)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.IMG3)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.META)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.ORDER_DETAIL)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SLIDER>()
                .Property(e => e.IMG)
                .IsUnicode(false);

            modelBuilder.Entity<SLIDER>()
                .Property(e => e.META)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.META)
                .IsUnicode(false);
        }
    }
}
