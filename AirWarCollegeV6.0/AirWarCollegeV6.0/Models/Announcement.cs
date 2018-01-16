namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Announcement")]
    public partial class Announcement
    {
        public int ID { get; set; }

        [Required]
        public string announcementText { get; set; }

        [Column(TypeName = "date")]
        public DateTime announcementDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime expiresAt { get; set; }
    }
}
