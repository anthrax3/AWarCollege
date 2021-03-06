namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Commandant
    {
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Rank { get; set; }

        [Column(TypeName = "date")]
        public DateTime startedAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime endedAt { get; set; }

        public byte[] Image { get; set; }
    }
}
