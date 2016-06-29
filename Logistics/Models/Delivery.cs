namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.Delivery")]
    public partial class Delivery
    {
        [Key]
        public int DeliveryNo { get; set; }

        public int? PackNo { get; set; }

        public int? Network { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public int? DeliveryClass { get; set; }

        public int? DeliveryStatus { get; set; }

        public int? DeliveryStorage { get; set; }
    }
}
