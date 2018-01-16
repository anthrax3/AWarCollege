namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Synopsis")]
    public partial class Synopsis
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string uploaderName { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        public byte[] File { get; set; }
    }
}
