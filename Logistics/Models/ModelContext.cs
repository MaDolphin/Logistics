namespace Logistics.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Dispatch> Dispatch { get; set; }
        public virtual DbSet<LogDetail> LogDetail { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BookName)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BookAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BookItems)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.ComplaintName)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.ComplaintContent)
                .IsUnicode(false);

            modelBuilder.Entity<Dispatch>()
                .Property(e => e.PackName)
                .IsUnicode(false);

            modelBuilder.Entity<Dispatch>()
                .Property(e => e.ToName)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.FromProvince)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.FromCity)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.FromStatue)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.FromAddress)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.FromName)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.ToProvince)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.ToCity)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.ToStatue)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.ToAddress)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.ToName)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.Pay)
                .IsUnicode(false);

            modelBuilder.Entity<LogDetail>()
                .Property(e => e.PackName)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.Network)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.Storage)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.OutboundStorage)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.CourierNo)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Storage>()
                .Property(e => e.StorageNetwork)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
