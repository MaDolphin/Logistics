namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.Storage")]
    public partial class Storage
    {
        [Key]
        public int StorageNo { get; set; }

        public int? PackNo { get; set; }

        [Column("Storage")]
        public int? Storage1 { get; set; }

        public DateTime? StorageTime { get; set; }

        public int? StorageType { get; set; }

        public int? StorageNetwork { get; set; }
    }
}
