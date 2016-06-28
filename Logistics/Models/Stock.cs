namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.Stock")]
    public partial class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackNo { get; set; }

        public int? Storage { get; set; }

        public DateTime? StockTime { get; set; }

        public int? StockStatus { get; set; }
    }
}
