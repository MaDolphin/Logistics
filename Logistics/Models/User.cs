namespace Logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logistics.User")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Account { get; set; }

        [Column(TypeName = "char")]
        [StringLength(30)]
        public string UserName { get; set; }

        [Column(TypeName = "char")]
        [StringLength(20)]
        public string Password { get; set; }

        public int? Permissions { get; set; }
    }
}
