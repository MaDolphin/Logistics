namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.Complaint")]
    public partial class Complaint
    {
        [Key]
        public int ComplaintNo { get; set; }

        public int? PackNo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(20)]
        public string ComplaintName { get; set; }

        public int? ComplaintTel { get; set; }

        [StringLength(300)]
        public string ComplaintContent { get; set; }
    }
}
