namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Study Material")]
    public partial class Study_Material
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string uploaderName { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
