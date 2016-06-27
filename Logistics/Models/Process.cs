namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.Process")]
    public partial class Process
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackNo { get; set; }

        public int? DeliveryNo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string Network { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public int? StorageNo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string Storage { get; set; }

        public DateTime? StorageTime { get; set; }

        public int? OutboundNo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string OutboundStorage { get; set; }

        public DateTime? OutboundTime { get; set; }

        public int? DispatchNo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string CourierNo { get; set; }

        public DateTime? DispatchTime { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string Location { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }
    }
}
