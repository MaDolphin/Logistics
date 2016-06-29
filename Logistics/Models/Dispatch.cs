namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.Dispatch")]
    public partial class Dispatch
    {
        [Key]
        public int DispatchNo { get; set; }

        public int? PackNo { get; set; }

        public int? CourierNo { get; set; }

        [StringLength(30)]
        public string PackName { get; set; }

        [StringLength(20)]
        public string ToName { get; set; }

        public DateTime? DispatchTime { get; set; }

        public int? DispatchStatus { get; set; }

        public int? ToTel { get; set; }

        [StringLength(50)]
        public string ToAddresss { get; set; }
    }
}
