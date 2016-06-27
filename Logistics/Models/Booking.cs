namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.Booking")]
    public partial class Booking
    {
        [Key]
        public int BookNo { get; set; }

        [StringLength(30)]
        public string BookName { get; set; }

        public int? BookTel { get; set; }

        [StringLength(30)]
        public string BookAddress { get; set; }

        [StringLength(150)]
        public string BookItems { get; set; }

        public DateTime? BookGetTime { get; set; }

        public DateTime? BookStartTime { get; set; }
    }
}
