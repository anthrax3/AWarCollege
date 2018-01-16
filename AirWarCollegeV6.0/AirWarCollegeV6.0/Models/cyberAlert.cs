namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cyberAlert")]
    public partial class cyberAlert
    {
        public int ID { get; set; }

        [Required]
        public string cyberAlertText { get; set; }

        [Column(TypeName = "date")]
        public DateTime cyberAlertDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime expiresAt { get; set; }
    }
}
