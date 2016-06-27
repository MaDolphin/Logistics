namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.LogDetail")]
    public partial class LogDetail
    {
        [Key]
        public int PackNo { get; set; }

        [StringLength(10)]
        public string FromProvince { get; set; }

        [StringLength(10)]
        public string FromCity { get; set; }

        [StringLength(10)]
        public string FromStatue { get; set; }

        [StringLength(50)]
        public string FromAddress { get; set; }

        [StringLength(10)]
        public string FromName { get; set; }

        public int? FromTel { get; set; }

        [StringLength(10)]
        public string ToProvince { get; set; }

        [StringLength(10)]
        public string ToCity { get; set; }

        [StringLength(10)]
        public string ToStatue { get; set; }

        [StringLength(50)]
        public string ToAddress { get; set; }

        [StringLength(10)]
        public string ToName { get; set; }

        public int? ToTel { get; set; }

        [StringLength(10)]
        public string Pay { get; set; }

        [StringLength(10)]
        public string PackName { get; set; }

        public double? Weight { get; set; }

        public double? Momey { get; set; }

        public int? Status { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
